using System.Linq;
using dotnetPartThree.Api.Models.Dtos;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Models
{
    public class ModelFactory
    {
        protected LinkGenerator _linkGenerator;
        protected ActionContext _context;
        private string _baseUrl;
        public ModelFactory()
        {}

        public ModelFactory(ActionContext context, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _context = context;
            _baseUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.PathBase}";
        }

        public CategoryDto Create(Category category)
        {
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "CategoriesApi", action: "Get", values: new { id = category.CategoryId})
            };
        }
        public CustomerDto Create(Customer customer)
        {
            return new CustomerDto
            {
                Address = customer.Address,
                City = customer.City,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Country = customer.Country,
                CustomerId = customer.CustomerId,
                Fax = customer.Fax,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Region = customer.Region,
                Orders = customer.Orders.Select(Create),
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "CustomerApi", action: "Get", values: new { id = customer.CustomerId})
            };
        }
        public CustomerDemographicDto Create(CustomerDemographic customerDemographic)
        {
            return new CustomerDemographicDto
            {
                CustomerDesc = customerDemographic.CustomerDesc,
                CustomerTypeId = customerDemographic.CustomerTypeId
            };
        }
        public EmployeeDto Create(Employee employee)
        {
            return new EmployeeDto
            {
                Address = employee.Address,
                BirthDate = employee.BirthDate,
                City = employee.City,
                Country = employee.Country,
                EmployeeId = employee.EmployeeId,
                Extension = employee.Extension,
                FirstName = employee.FirstName,
                HireDate = employee.HireDate,
                HomePhone = employee.HomePhone,
                LastName = employee.LastName,
                Notes = employee.Notes,
                PhotoPath = employee.PhotoPath,
                PostalCode = employee.PostalCode,
                Region = employee.Region,
                ReportsTo = employee.ReportsTo,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "EmployeeApi", action: "Get", values: new { id = employee.EmployeeId}),
                EmployeeTerritories = employee.EmployeeTerritories.Select(Create),
                Orders = employee.Orders.Select(Create),
                ReportsToNavigation = employee.InverseReportsToNavigation.Select(Create)
            };
        }
        public EmployeeTerritoryDto Create(EmployeeTerritory employeeTerritory)
        {
            return new EmployeeTerritoryDto
            {
                EmployeeId = employeeTerritory.EmployeeId,
                TerritoryId = employeeTerritory.TerritoryId
            };
        }
        public OrderDto Create(Order order)
        {
            return new OrderDto
            {
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                Freight = order.Freight,
                OrderDate = order.OrderDate,
                OrderId = order.OrderId,
                RequiredDate = order.RequiredDate,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipName = order.ShipName,
                ShippedDate = order.ShippedDate,
                ShipRegion = order.ShipRegion,
                ShipVia = order.ShipVia,
                ShipPostalCode = order.ShipPostalCode,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "OrderApi", action: "Get", values: new { id = order.OrderId}),
                OrderDetailDtos = order.OrderDetails.Select(Create)
            };
        }
        public OrderDetailDto Create(OrderDetail orderDetail)
        {
            return new OrderDetailDto
            {
                Discount = orderDetail.Discount,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                UnitPrice = orderDetail.UnitPrice,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "OrderDetailApi", action: "Get", values: new { orderId = orderDetail.OrderId, productId = orderDetail.ProductId})
            };
        }
        public ProductDto Create(Product product)
        {
            return new ProductDto
            {
                CategoryId = product.CategoryId,
                Discountinued = product.Discontinued,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                SupplierId = product.SupplierId,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "ProductApi", action: "Get", values: new { id = product.ProductId}),
                CategoryUrl = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "CategoriesApi", action: "Get", values: new { id = product.CategoryId})
            };
        }
        public RegionDto Create(Region region)
        {
            return new RegionDto
            {
                RegionId = region.RegionId, 
                RegionDescription = region.RegionDescription,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "RegionApi", action: "Get", values: new { id = region.RegionId})
            };
        }
        public ShipperDto Create(Shipper shipper)
        {
            return new ShipperDto
            {
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
                ShipperId = shipper.ShipperId,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "ShipperApi", action: "Get", values: new { id = shipper.ShipperId})
            };
        }
        public SupplierDto Create(Supplier supplier)
        {
            return new SupplierDto
            {
                 Address = supplier.Address,
                 City = supplier.City,
                 CompanyName = supplier.CompanyName,
                 ContactName = supplier.ContactName,
                 ContactTitle = supplier.ContactTitle,
                 Country = supplier.Country,
                 Fax = supplier.Fax,
                 HomePage = supplier.HomePage,
                 Phone = supplier.Phone,
                 PostalCode = supplier.PostalCode,
                 Region = supplier.Region,
                 SupplierId = supplier.SupplierId,
                 //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "SupplierApi", action: "Get", values: new { id = supplier.SupplierId})
            };
        }
        public TerritoryDto Create(Territory territory)
        {
            return new TerritoryDto
            {
                RegionId = territory.RegionId,
                TerritoryDescription = territory.TerritoryDescription,
                TerritoryId = territory.TerritoryId,
                //Url = _baseUrl + _linkGenerator.GetPathByAction(_context.HttpContext, controller: "TerritoryApi", action: "Get", values: new { id = territory.TerritoryId})
            };
        }        
    }
}