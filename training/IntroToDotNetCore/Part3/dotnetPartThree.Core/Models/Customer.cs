using System.Collections.Generic;

namespace dotnetPartThree.Core.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            Orders = new List<Order>();
        }
        
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        
        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}