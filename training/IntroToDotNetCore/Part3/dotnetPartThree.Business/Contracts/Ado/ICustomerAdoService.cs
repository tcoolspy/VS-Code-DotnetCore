using System.Collections.Generic;
using dotnetPartThree.Core.Framework.Contracts.Ado;
using dotnetPartThree.Core.Models;

namespace dotnetPartThree.Business.Contracts.Ado
{
    public interface ICustomerAdoService : IGenericAdoBusinessService<Customer>
    {
        IEnumerable<Customer> GetCustomerDetails();
        int InsertCustomerDetails(Customer customer);
    }
}