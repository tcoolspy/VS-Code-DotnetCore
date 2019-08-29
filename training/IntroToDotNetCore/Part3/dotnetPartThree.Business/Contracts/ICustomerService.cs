using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;

namespace dotnetPartThree.Business.Contracts
{
    public interface ICustomerService : IGenericBusinessService<Customer, string>
    {
         Customer GetCustomerWithOrders(string customerId);
    }
}