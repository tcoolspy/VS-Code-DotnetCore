create type empid from char(9) not null
go

create type id from varchar(11) not null
go

create type tid from varchar(6) not null
go

create table authors
(
    au_id    id                         not null
        constraint UPKCL_auidind
            primary key
        check ([au_id] like '[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]'),
    au_lname varchar(40)                not null,
    au_fname varchar(20)                not null,
    phone    char(12) default 'UNKNOWN' not null,
    address  varchar(40),
    city     varchar(20),
    state    char(2),
    zip      char(5)
        check ([zip] like '[0-9][0-9][0-9][0-9][0-9]'),
    contract bit                        not null
)
go

create index aunmind
    on authors (au_lname, au_fname)
go

create table jobs
(
    job_id   smallint identity
        primary key,
    job_desc varchar(50) default 'New Position - title not formalized yet' not null,
    min_lvl  tinyint                                                       not null
        check ([min_lvl] >= 10),
    max_lvl  tinyint                                                       not null
        check ([max_lvl] <= 250)
)
go

create table publishers
(
    pub_id   char(4) not null
        constraint UPKCL_pubind
            primary key
        check ([pub_id] = '1756' OR [pub_id] = '1622' OR [pub_id] = '0877' OR [pub_id] = '0736' OR [pub_id] = '1389' OR
               [pub_id] like '99[0-9][0-9]'),
    pub_name varchar(40),
    city     varchar(20),
    state    char(2),
    country  varchar(30) default 'USA'
)
go

create table employee
(
    emp_id    empid                      not null
        constraint PK_emp_id
            primary key nonclustered
        constraint CK_emp_id
            check ([emp_id] like '[A-Z][A-Z][A-Z][1-9][0-9][0-9][0-9][0-9][FM]' OR
                   [emp_id] like '[A-Z]-[A-Z][1-9][0-9][0-9][0-9][0-9][FM]'),
    fname     varchar(20)                not null,
    minit     char,
    lname     varchar(30)                not null,
    job_id    smallint default 1         not null
        references jobs,
    job_lvl   tinyint  default 10,
    pub_id    char(4)  default '9952'    not null
        references publishers,
    hire_date datetime default getdate() not null
)
go

create clustered index employee_ind
    on employee (fname, minit, lname)
go


CREATE TRIGGER employee_insupd
    ON employee
    FOR insert, UPDATE
    AS
--Get the range of level for this job type from the jobs table.
    declare
        @min_lvl tinyint,
        @max_lvl tinyint,
        @emp_lvl tinyint,
        @job_id  smallint
select @min_lvl = min_lvl,
       @max_lvl = max_lvl,
       @emp_lvl = i.job_lvl,
       @job_id = i.job_id
from employee e,
     jobs j,
     inserted i
where e.emp_id = i.emp_id
  AND i.job_id = j.job_id
IF (@job_id = 1) and (@emp_lvl <> 10)
    begin
        raiserror ('Job id 1 expects the default level of 10.',16,1)
        ROLLBACK TRANSACTION
    end
ELSE
    IF NOT (@emp_lvl BETWEEN @min_lvl AND @max_lvl)
        begin
            raiserror ('The level for job_id:%d should be between %d and %d.',
                16, 1, @job_id, @min_lvl, @max_lvl)
            ROLLBACK TRANSACTION
        end

go

create table pub_info
(
    pub_id  char(4) not null
        constraint UPKCL_pubinfo
            primary key
        references publishers,
    logo    image,
    pr_info text
)
go

create table stores
(
    stor_id      char(4) not null
        constraint UPK_storeid
            primary key,
    stor_name    varchar(40),
    stor_address varchar(40),
    city         varchar(20),
    state        char(2),
    zip          char(5)
)
go

create table discounts
(
    discounttype varchar(40)   not null,
    stor_id      char(4)
        references stores,
    lowqty       smallint,
    highqty      smallint,
    discount     decimal(4, 2) not null
)
go

create table titles
(
    title_id  tid                          not null
        constraint UPKCL_titleidind
            primary key,
    title     varchar(80)                  not null,
    type      char(12) default 'UNDECIDED' not null,
    pub_id    char(4)
        references publishers,
    price     money,
    advance   money,
    royalty   int,
    ytd_sales int,
    notes     varchar(200),
    pubdate   datetime default getdate()   not null
)
go

create table roysched
(
    title_id tid not null
        references titles,
    lorange  int,
    hirange  int,
    royalty  int
)
go

create index titleidind
    on roysched (title_id)
go

create table sales
(
    stor_id  char(4)     not null
        references stores,
    ord_num  varchar(20) not null,
    ord_date datetime    not null,
    qty      smallint    not null,
    payterms varchar(12) not null,
    title_id tid         not null
        references titles,
    constraint UPKCL_sales
        primary key (stor_id, ord_num, title_id)
)
go

create index titleidind
    on sales (title_id)
go

create table titleauthor
(
    au_id      id  not null
        references authors,
    title_id   tid not null
        references titles,
    au_ord     tinyint,
    royaltyper int,
    constraint UPKCL_taind
        primary key (au_id, title_id)
)
go

create index auidind
    on titleauthor (au_id)
go

create index titleidind
    on titleauthor (title_id)
go

create index titleind
    on titles (title)
go


CREATE VIEW titleview
AS
select title, au_ord, au_lname, price, ytd_sales, pub_id
from authors,
     titles,
     titleauthor
where authors.au_id = titleauthor.au_id
  AND titles.title_id = titleauthor.title_id

go


CREATE PROCEDURE byroyalty @percentage int
AS
select au_id
from titleauthor
where titleauthor.royaltyper = @percentage

go


CREATE PROCEDURE reptq1 AS
select case when grouping(pub_id) = 1 then 'ALL' else pub_id end as pub_id,
       avg(price)                                                as avg_price
from titles
where price is NOT NULL
group by pub_id
with rollup
order by pub_id

go


CREATE PROCEDURE reptq2 AS
select case when grouping(type) = 1 then 'ALL' else type end     as type,
       case when grouping(pub_id) = 1 then 'ALL' else pub_id end as pub_id,
       avg(ytd_sales)                                            as avg_ytd_sales
from titles
where pub_id is NOT NULL
group by pub_id, type
with rollup

go


CREATE PROCEDURE reptq3 @lolimit money, @hilimit money,
                        @type char(12)
AS
select case when grouping(pub_id) = 1 then 'ALL' else pub_id end as pub_id,
       case when grouping(type) = 1 then 'ALL' else type end     as type,
       count(title_id)                                           as cnt
from titles
where price > @lolimit AND price < @hilimit AND type = @type
   OR type LIKE '%cook%'
group by pub_id, type
with rollup

go

