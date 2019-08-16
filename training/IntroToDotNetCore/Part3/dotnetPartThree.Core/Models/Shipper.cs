using System.Collections.Generic;

namespace dotnetPartThree.Core.Models
{
    public class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }
        
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}