create table Northwind.dbo.Categories
(
    CategoryID   int identity
        constraint PK_Categories
            primary key,
    CategoryName nvarchar(15) not null,
    Description  ntext,
    Picture      image
)
go

create index CategoryName
    on Northwind.dbo.Categories (CategoryName)
go

create table Northwind.dbo.CustomerDemographics
(
    CustomerTypeID nchar(10) not null
        constraint PK_CustomerDemographics
            primary key nonclustered,
    CustomerDesc   ntext
)
go

create table Northwind.dbo.Customers
(
    CustomerID   nchar(5)     not null
        constraint PK_Customers
            primary key,
    CompanyName  nvarchar(40) not null,
    ContactName  nvarchar(30),
    ContactTitle nvarchar(30),
    Address      nvarchar(60),
    City         nvarchar(15),
    Region       nvarchar(15),
    PostalCode   nvarchar(10),
    Country      nvarchar(15),
    Phone        nvarchar(24),
    Fax          nvarchar(24)
)
go

create table Northwind.dbo.CustomerCustomerDemo
(
    CustomerID     nchar(5)  not null
        constraint FK_CustomerCustomerDemo_Customers
            references Northwind.dbo.Customers,
    CustomerTypeID nchar(10) not null
        constraint FK_CustomerCustomerDemo
            references Northwind.dbo.CustomerDemographics,
    constraint PK_CustomerCustomerDemo
        primary key nonclustered (CustomerID, CustomerTypeID)
)
go

create index City
    on Northwind.dbo.Customers (City)
go

create index CompanyName
    on Northwind.dbo.Customers (CompanyName)
go

create index PostalCode
    on Northwind.dbo.Customers (PostalCode)
go

create index Region
    on Northwind.dbo.Customers (Region)
go

create table Northwind.dbo.Employees
(
    EmployeeID      int identity
        constraint PK_Employees
            primary key,
    LastName        nvarchar(20) not null,
    FirstName       nvarchar(10) not null,
    Title           nvarchar(30),
    TitleOfCourtesy nvarchar(25),
    BirthDate       datetime
        constraint CK_Birthdate
            check ([BirthDate] < getdate()),
    HireDate        datetime,
    Address         nvarchar(60),
    City            nvarchar(15),
    Region          nvarchar(15),
    PostalCode      nvarchar(10),
    Country         nvarchar(15),
    HomePhone       nvarchar(24),
    Extension       nvarchar(4),
    Photo           image,
    Notes           nvarchar(max),
    ReportsTo       int
        constraint FK_Employees_Employees
            references Northwind.dbo.Employees,
    PhotoPath       nvarchar(255)
)
go

create index LastName
    on Northwind.dbo.Employees (LastName)
go

create index PostalCode
    on Northwind.dbo.Employees (PostalCode)
go

create table Northwind.dbo.Region
(
    RegionID          int       not null
        constraint PK_Region
            primary key nonclustered,
    RegionDescription nchar(50) not null
)
go

create table Northwind.dbo.Shippers
(
    ShipperID   int identity
        constraint PK_Shippers
            primary key,
    CompanyName nvarchar(40) not null,
    Phone       nvarchar(24)
)
go

create table Northwind.dbo.Orders
(
    OrderID        int identity
        constraint PK_Orders
            primary key,
    CustomerID     nchar(5)
        constraint FK_Orders_Customers
            references Northwind.dbo.Customers,
    EmployeeID     int
        constraint FK_Orders_Employees
            references Northwind.dbo.Employees,
    OrderDate      datetime,
    RequiredDate   datetime,
    ShippedDate    datetime,
    ShipVia        int
        constraint FK_Orders_Shippers
            references Northwind.dbo.Shippers,
    Freight        money
        constraint DF_Orders_Freight default 0,
    ShipName       nvarchar(40),
    ShipAddress    nvarchar(60),
    ShipCity       nvarchar(15),
    ShipRegion     nvarchar(15),
    ShipPostalCode nvarchar(10),
    ShipCountry    nvarchar(15)
)
go

create index CustomerID
    on Northwind.dbo.Orders (CustomerID)
go

create index CustomersOrders
    on Northwind.dbo.Orders (CustomerID)
go

create index EmployeeID
    on Northwind.dbo.Orders (EmployeeID)
go

create index EmployeesOrders
    on Northwind.dbo.Orders (EmployeeID)
go

create index OrderDate
    on Northwind.dbo.Orders (OrderDate)
go

create index ShippedDate
    on Northwind.dbo.Orders (ShippedDate)
go

create index ShippersOrders
    on Northwind.dbo.Orders (ShipVia)
go

create index ShipPostalCode
    on Northwind.dbo.Orders (ShipPostalCode)
go

create table Northwind.dbo.Suppliers
(
    SupplierID   int identity
        constraint PK_Suppliers
            primary key,
    CompanyName  nvarchar(40) not null,
    ContactName  nvarchar(30),
    ContactTitle nvarchar(30),
    Address      nvarchar(60),
    City         nvarchar(15),
    Region       nvarchar(15),
    PostalCode   nvarchar(10),
    Country      nvarchar(15),
    Phone        nvarchar(24),
    Fax          nvarchar(24),
    HomePage     ntext
)
go

create table Northwind.dbo.Products
(
    ProductID       int identity
        constraint PK_Products
            primary key,
    ProductName     nvarchar(40)                      not null,
    SupplierID      int
        constraint FK_Products_Suppliers
            references Northwind.dbo.Suppliers,
    CategoryID      int
        constraint FK_Products_Categories
            references Northwind.dbo.Categories,
    QuantityPerUnit nvarchar(20),
    UnitPrice       money
        constraint DF_Products_UnitPrice default 0
        constraint CK_Products_UnitPrice
            check ([UnitPrice] >= 0),
    UnitsInStock    smallint
        constraint DF_Products_UnitsInStock default 0
        constraint CK_UnitsInStock
            check ([UnitsInStock] >= 0),
    UnitsOnOrder    smallint
        constraint DF_Products_UnitsOnOrder default 0
        constraint CK_UnitsOnOrder
            check ([UnitsOnOrder] >= 0),
    ReorderLevel    smallint
        constraint DF_Products_ReorderLevel default 0
        constraint CK_ReorderLevel
            check ([ReorderLevel] >= 0),
    Discontinued    bit
        constraint DF_Products_Discontinued default 0 not null
)
go

create table Northwind.dbo.[Order Details]
(
    OrderID   int                                       not null
        constraint FK_Order_Details_Orders
            references Northwind.dbo.Orders,
    ProductID int                                       not null
        constraint FK_Order_Details_Products
            references Northwind.dbo.Products,
    UnitPrice money
        constraint DF_Order_Details_UnitPrice default 0 not null
        constraint CK_UnitPrice
            check ([UnitPrice] >= 0),
    Quantity  smallint
        constraint DF_Order_Details_Quantity default 1  not null
        constraint CK_Quantity
            check ([Quantity] > 0),
    Discount  real
        constraint DF_Order_Details_Discount default 0  not null
        constraint CK_Discount
            check ([Discount] >= 0 AND [Discount] <= 1),
    constraint PK_Order_Details
        primary key (OrderID, ProductID)
)
go

create index OrderID
    on Northwind.dbo.[Order Details] (OrderID)
go

create index OrdersOrder_Details
    on Northwind.dbo.[Order Details] (OrderID)
go

create index ProductID
    on Northwind.dbo.[Order Details] (ProductID)
go

create index ProductsOrder_Details
    on Northwind.dbo.[Order Details] (ProductID)
go

create index CategoriesProducts
    on Northwind.dbo.Products (CategoryID)
go

create index CategoryID
    on Northwind.dbo.Products (CategoryID)
go

create index ProductName
    on Northwind.dbo.Products (ProductName)
go

create index SupplierID
    on Northwind.dbo.Products (SupplierID)
go

create index SuppliersProducts
    on Northwind.dbo.Products (SupplierID)
go

create index CompanyName
    on Northwind.dbo.Suppliers (CompanyName)
go

create index PostalCode
    on Northwind.dbo.Suppliers (PostalCode)
go

create table Northwind.dbo.Territories
(
    TerritoryID          nvarchar(20) not null
        constraint PK_Territories
            primary key nonclustered,
    TerritoryDescription nchar(50)    not null,
    RegionID             int          not null
        constraint FK_Territories_Region
            references Northwind.dbo.Region
)
go

create table Northwind.dbo.EmployeeTerritories
(
    EmployeeID  int          not null
        constraint FK_EmployeeTerritories_Employees
            references Northwind.dbo.Employees,
    TerritoryID nvarchar(20) not null
        constraint FK_EmployeeTerritories_Territories
            references Northwind.dbo.Territories,
    constraint PK_EmployeeTerritories
        primary key nonclustered (EmployeeID, TerritoryID)
)
go


-- create view Northwind.dbo."Alphabetical list of products" AS
-- SELECT Northwind.dbo.Products.*, Northwind.dbo.Categories.CategoryName
-- FROM Categories
--          INNER JOIN Northwind.dbo.Products ON Northwind.dbo.Categories.CategoryID = Northwind.dbo.Products.CategoryID
-- WHERE (((Northwind.dbo.Products.Discontinued) = 0))
-- go
--
--
-- create view "Category Sales for 1997" AS
-- SELECT "Product Sales for 1997".CategoryName, Sum("Product Sales for 1997".ProductSales) AS CategorySales
-- FROM "Product Sales for 1997"
-- GROUP BY "Product Sales for 1997".CategoryName
-- go
--
--
-- create view "Current Product List" AS
-- SELECT Product_List.ProductID, Product_List.ProductName
-- FROM Products AS Product_List
-- WHERE (((Product_List.Discontinued) = 0))
-- --ORDER BY Product_List.ProductName
-- go
--
--
-- create view "Customer and Suppliers by City" AS
-- SELECT City, CompanyName, ContactName, 'Customers' AS Relationship
-- FROM Customers
-- UNION
-- SELECT City, CompanyName, ContactName, 'Suppliers'
-- FROM Suppliers
-- --ORDER BY City, CompanyName
-- go
--
--
-- create view Invoices AS
-- SELECT Orders.ShipName,
--        Orders.ShipAddress,
--        Orders.ShipCity,
--        Orders.ShipRegion,
--        Orders.ShipPostalCode,
--        Orders.ShipCountry,
--        Orders.CustomerID,
--        Customers.CompanyName                                                                 AS CustomerName,
--        Customers.Address,
--        Customers.City,
--        Customers.Region,
--        Customers.PostalCode,
--        Customers.Country,
--        (FirstName + ' ' + LastName)                                                          AS Salesperson,
--        Orders.OrderID,
--        Orders.OrderDate,
--        Orders.RequiredDate,
--        Orders.ShippedDate,
--        Shippers.CompanyName                                                                  As ShipperName,
--        "Order Details".ProductID,
--        Products.ProductName,
--        "Order Details".UnitPrice,
--        "Order Details".Quantity,
--        "Order Details".Discount,
--        (CONVERT(money, ("Order Details".UnitPrice * Quantity * (1 - Discount) / 100)) * 100) AS ExtendedPrice,
--        Orders.Freight
-- FROM Shippers
--          INNER JOIN
--      (Products INNER JOIN
--          (
--              (Employees INNER JOIN
--                  (Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID)
--                  ON Employees.EmployeeID = Orders.EmployeeID)
--                  INNER JOIN "Order Details" ON Orders.OrderID = "Order Details".OrderID)
--          ON Products.ProductID = "Order Details".ProductID)
--      ON Shippers.ShipperID = Orders.ShipVia
-- go
--
--
-- create view "Order Details Extended" AS
-- SELECT "Order Details".OrderID,
--        "Order Details".ProductID,
--        Products.ProductName,
--        "Order Details".UnitPrice,
--        "Order Details".Quantity,
--        "Order Details".Discount,
--        (CONVERT(money, ("Order Details".UnitPrice * Quantity * (1 - Discount) / 100)) * 100) AS ExtendedPrice
-- FROM Products
--          INNER JOIN "Order Details" ON Products.ProductID = "Order Details".ProductID
-- --ORDER BY "Order Details".OrderID
-- go
--
--
-- create view "Order Subtotals" AS
-- SELECT "Order Details".OrderID,
--        Sum(CONVERT(money, ("Order Details".UnitPrice * Quantity * (1 - Discount) / 100)) * 100) AS Subtotal
-- FROM "Order Details"
-- GROUP BY "Order Details".OrderID
-- go
--
--
-- create view "Orders Qry" AS
-- SELECT Orders.OrderID,
--        Orders.CustomerID,
--        Orders.EmployeeID,
--        Orders.OrderDate,
--        Orders.RequiredDate,
--        Orders.ShippedDate,
--        Orders.ShipVia,
--        Orders.Freight,
--        Orders.ShipName,
--        Orders.ShipAddress,
--        Orders.ShipCity,
--        Orders.ShipRegion,
--        Orders.ShipPostalCode,
--        Orders.ShipCountry,
--        Customers.CompanyName,
--        Customers.Address,
--        Customers.City,
--        Customers.Region,
--        Customers.PostalCode,
--        Customers.Country
-- FROM Customers
--          INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
-- go
--
--
-- create view "Product Sales for 1997" AS
-- SELECT Categories.CategoryName,
--        Products.ProductName,
--        Sum(CONVERT(money, ("Order Details".UnitPrice * Quantity * (1 - Discount) / 100)) * 100) AS ProductSales
-- FROM (Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID)
--          INNER JOIN (Orders
--     INNER JOIN "Order Details" ON Orders.OrderID = "Order Details".OrderID)
--                     ON Products.ProductID = "Order Details".ProductID
-- WHERE (((Orders.ShippedDate) Between '19970101' And '19971231'))
-- GROUP BY Categories.CategoryName, Products.ProductName
-- go
--
--
-- create view "Products Above Average Price" AS
-- SELECT Products.ProductName, Products.UnitPrice
-- FROM Products
-- WHERE Products.UnitPrice > (SELECT AVG(UnitPrice) From Products)
-- --ORDER BY Products.UnitPrice DESC
-- go
--
--
-- create view "Products by Category" AS
-- SELECT Categories.CategoryName,
--        Products.ProductName,
--        Products.QuantityPerUnit,
--        Products.UnitsInStock,
--        Products.Discontinued
-- FROM Categories
--          INNER JOIN Products ON Categories.CategoryID = Products.CategoryID
-- WHERE Products.Discontinued <> 1
-- --ORDER BY Categories.CategoryName, Products.ProductName
-- go
--
--
-- create view "Quarterly Orders" AS
-- SELECT DISTINCT Customers.CustomerID, Customers.CompanyName, Customers.City, Customers.Country
-- FROM Customers
--          RIGHT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
-- WHERE Orders.OrderDate BETWEEN '19970101' And '19971231'
-- go
--
--
-- create view "Sales Totals by Amount" AS
-- SELECT "Order Subtotals".Subtotal AS SaleAmount, Orders.OrderID, Customers.CompanyName, Orders.ShippedDate
-- FROM Customers
--          INNER JOIN
--      (Orders INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID)
--      ON Customers.CustomerID = Orders.CustomerID
-- WHERE ("Order Subtotals".Subtotal > 2500)
--   AND (Orders.ShippedDate BETWEEN '19970101' And '19971231')
-- go
--
--
-- create view "Sales by Category" AS
-- SELECT Categories.CategoryID,
--        Categories.CategoryName,
--        Products.ProductName,
--        Sum("Order Details Extended".ExtendedPrice) AS ProductSales
-- FROM Categories
--          INNER JOIN
--      (Products INNER JOIN
--          (Orders INNER JOIN "Order Details Extended" ON Orders.OrderID = "Order Details Extended".OrderID)
--          ON Products.ProductID = "Order Details Extended".ProductID)
--      ON Categories.CategoryID = Products.CategoryID
-- WHERE Orders.OrderDate BETWEEN '19970101' And '19971231'
-- GROUP BY Categories.CategoryID, Categories.CategoryName, Products.ProductName
-- --ORDER BY Products.ProductName
-- go
--
--
-- create view "Summary of Sales by Quarter" AS
-- SELECT Orders.ShippedDate, Orders.OrderID, "Order Subtotals".Subtotal
-- FROM Orders
--          INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID
-- WHERE Orders.ShippedDate IS NOT NULL
-- --ORDER BY Orders.ShippedDate
-- go
--
--
-- create view "Summary of Sales by Year" AS
-- SELECT Orders.ShippedDate, Orders.OrderID, "Order Subtotals".Subtotal
-- FROM Orders
--          INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID
-- WHERE Orders.ShippedDate IS NOT NULL
-- --ORDER BY Orders.ShippedDate
-- go
--
-- CREATE PROCEDURE CustOrderHist @CustomerID nchar(5)
-- AS
-- SELECT ProductName, Total=SUM(Quantity)
-- FROM Products P,
--      [Order Details] OD,
--      Orders O,
--      Customers C
-- WHERE C.CustomerID = @CustomerID
--   AND C.CustomerID = O.CustomerID
--   AND O.OrderID = OD.OrderID
--   AND OD.ProductID = P.ProductID
-- GROUP BY ProductName
-- go
--
--
-- CREATE PROCEDURE CustOrdersDetail @OrderID int
-- AS
-- SELECT ProductName,
--        UnitPrice=ROUND(Od.UnitPrice, 2),
--        Quantity,
--        Discount=CONVERT(int, Discount * 100),
--        ExtendedPrice=ROUND(CONVERT(money, Quantity * (1 - Discount) * Od.UnitPrice), 2)
-- FROM Products P,
--      [Order Details] Od
-- WHERE Od.ProductID = P.ProductID
--   and Od.OrderID = @OrderID
-- go
--
--
-- CREATE PROCEDURE CustOrdersOrders @CustomerID nchar(5)
-- AS
-- SELECT OrderID,
--        OrderDate,
--        RequiredDate,
--        ShippedDate
-- FROM Orders
-- WHERE CustomerID = @CustomerID
-- ORDER BY OrderID
-- go
--
--
-- create procedure "Employee Sales by Country" @Beginning_Date DateTime, @Ending_Date DateTime AS
-- SELECT Employees.Country,
--        Employees.LastName,
--        Employees.FirstName,
--        Orders.ShippedDate,
--        Orders.OrderID,
--        "Order Subtotals".Subtotal AS SaleAmount
-- FROM Employees
--          INNER JOIN
--      (Orders INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID)
--      ON Employees.EmployeeID = Orders.EmployeeID
-- WHERE Orders.ShippedDate Between @Beginning_Date And @Ending_Date
-- go
--
--
-- create procedure "Sales by Year" @Beginning_Date DateTime, @Ending_Date DateTime AS
-- SELECT Orders.ShippedDate, Orders.OrderID, "Order Subtotals".Subtotal, DATENAME(yy, ShippedDate) AS Year
-- FROM Orders
--          INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID
-- WHERE Orders.ShippedDate Between @Beginning_Date And @Ending_Date
-- go
--
-- CREATE PROCEDURE SalesByCategory @CategoryName nvarchar(15), @OrdYear nvarchar(4) = '1998'
-- AS
--     IF @OrdYear != '1996' AND @OrdYear != '1997' AND @OrdYear != '1998'
--         BEGIN
--             SELECT @OrdYear = '1998'
--         END
--
-- SELECT ProductName,
--        TotalPurchase=ROUND(SUM(CONVERT(decimal(14, 2), OD.Quantity * (1 - OD.Discount) * OD.UnitPrice)), 0)
-- FROM [Order Details] OD,
--      Orders O,
--      Products P,
--      Categories C
-- WHERE OD.OrderID = O.OrderID
--   AND OD.ProductID = P.ProductID
--   AND P.CategoryID = C.CategoryID
--   AND C.CategoryName = @CategoryName
--   AND SUBSTRING(CONVERT(nvarchar(22), O.OrderDate, 111), 1, 4) = @OrdYear
-- GROUP BY ProductName
-- ORDER BY ProductName
-- go
--
--
-- create procedure "Ten Most Expensive Products" AS
--     SET ROWCOUNT 10
-- SELECT Products.ProductName AS TenMostExpensiveProducts, Products.UnitPrice
-- FROM Products
-- ORDER BY Products.UnitPrice DESC
-- go
