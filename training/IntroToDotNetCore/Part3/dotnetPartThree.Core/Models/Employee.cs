using System;
using System.Collections.Generic;

namespace dotnetPartThree.Core.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new List<EmployeeTerritory>();
            InverseReportsToNavigation = new List<Employee>();
            Orders = new List<Order>();
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
        
        public virtual Employee ReportsToNavigation { get; set; }
        public virtual IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual IEnumerable<Employee> InverseReportsToNavigation { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}