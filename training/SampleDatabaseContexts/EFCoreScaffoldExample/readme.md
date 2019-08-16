These are sample Models and DbContext files for the following sample databases:

AdventureWorks2017
Northwind
Pubs
WideWorldImporters

They were generated using the dotnet ef scaffold command, such as:

dotnet ef dbcontext scaffold "Server=localhost,1433;Database=Northwind;User Id=sa;Password=<YourStrongPassword>" Microsoft.EntityFrameworkCore.SqlServer -o Model
