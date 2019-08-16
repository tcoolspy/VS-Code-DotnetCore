using System.Linq;
using dotnetPartThree.Business.Contracts;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetPartThree.Business.Services
{
    public class CustomerBusinessService : GenericBusinessService<Customer, string>, ICustomerBusinessService
    {
        public CustomerBusinessService(IGenericRepository<Customer, string> dataRepository) : base(dataRepository)
        {
        }
        
        public Customer GetCustomerWithOrders(string customerId)
        {
            using (var context = DataRepository.GetDbContext())
            {
                var customer = context.Set<Customer>()
                    .Include(x => x.Orders)
                    .ThenInclude(x => x.OrderDetails)
                    .FirstOrDefault(x => x.CustomerId == customerId);
                return customer;
            }
        }
    }        
}