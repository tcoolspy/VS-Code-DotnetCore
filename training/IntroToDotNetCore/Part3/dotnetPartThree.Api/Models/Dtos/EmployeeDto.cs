using System;
using System.Collections.Generic;

namespace dotnetPartThree.Api.Models.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            this.EmployeeTerritories = new List<EmployeeTerritoryDto>();
            this.Orders = new List<OrderDto>();
            this.ReportsToNavigation = new List<EmployeeDto>();
        }
        
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public string Url { get; set; }    
        public IEnumerable<EmployeeTerritoryDto> EmployeeTerritories { get; set; }
        public IEnumerable<EmployeeDto> ReportsToNavigation { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }        
    }
}