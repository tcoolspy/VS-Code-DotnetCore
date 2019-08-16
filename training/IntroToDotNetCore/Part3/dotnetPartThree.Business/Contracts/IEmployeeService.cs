using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;

namespace dotnetPartThree.Business.Contracts
{
    public interface IEmployeeService  : IGenericBusinessService<Employee, int>
    {
        Employee GetEmployeeWithOrders(int employeeId, int currentPage, int pageSize);         
    }
}