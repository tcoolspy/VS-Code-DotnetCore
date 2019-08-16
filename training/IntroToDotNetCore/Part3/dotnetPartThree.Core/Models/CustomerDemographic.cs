using System.Collections.Generic;

namespace dotnetPartThree.Core.Models
{
    public class CustomerDemographic
    {
        public CustomerDemographic()
        {
            CustomerCustomerDemo = new List<CustomerCustomerDemo>();
        }
        
        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }
        
        public virtual IEnumerable<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    }
}