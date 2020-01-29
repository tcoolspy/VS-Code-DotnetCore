using System.Collections.Generic;
using System.Linq;
using dotnetPartThree.Business.Contracts.Ado;
using dotnetPartThree.Core.Framework.Contracts.Ado;
using dotnetPartThree.Core.Models;

namespace dotnetPartThree.Business.Services.Ado
{
    
    public class CustomerAdoService : GenericAdoBusinessService<Customer>, ICustomerAdoService
    {
        public CustomerAdoService(IAdoRepository<Customer> dataRepository) : base(dataRepository)
        {
        }

        public IEnumerable<Customer> GetCustomerDetails()
        {
            // implement correct logic.
            return DataRepository.GetAll().AsEnumerable();
        }

        public int InsertCustomerDetails(Customer customer)
        {
            // implement correct logic.
            return DataRepository.Insert(customer);
        }
    }
}