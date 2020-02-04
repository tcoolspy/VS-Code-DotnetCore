create table ChatMessageLikes
(
    id            uniqueidentifier not null
        constraint ChatMessageLikes_pk
            primary key nonclustered,
    chatmessageid uniqueidentifier not null,
    chatuserid    uniqueidentifier not null,
    numberoflikes int default 0
)
go

create unique index ChatMessageLikes_id_uindex
    on ChatMessageLikes (id)
go

create table ChatMessages
(
    Id            uniqueidentifier           not null
        constraint ChatMessages_pk
            primary key nonclustered,
    Username      nvarchar(125)              not null,
    ChatText      nvarchar(max),
    DateTimeStamp datetime default getdate() not null,
    ChatUserId    uniqueidentifier           not null
)
go

create unique index ChatMessages_Id_uindex
    on ChatMessages (Id)
go

create table ChatUsers
(
    Id           uniqueidentifier not null
        constraint ChatUsers_pk
            primary key nonclustered,
    FirstName    nvarchar(50)     not null,
    LastName     nvarchar(50)     not null,
    Email        nvarchar(100)    not null,
    Avatar       nvarchar(max),
    PasswordHash varbinary(max),
    PasswordSalt varbinary(max)
)
go

create unique index ChatUsers_Id_uindex
    on ChatUsers (Id)
go

create table Students
(
    Id           uniqueidentifier not null
        constraint Students_pk
            primary key nonclustered,
    FirstName    nvarchar(50)     not null,
    LastName     nvarchar(50)     not null,
    Email        nvarchar(100)    not null,
    PasswordHash varbinary(max),
    PasswordSalt varbinary(max)
)
go

create unique index Students_Id_uindex
    on Students (Id)
go

