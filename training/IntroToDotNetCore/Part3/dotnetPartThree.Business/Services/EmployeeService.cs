using System.Linq;
using dotnetPartThree.Business.Contracts;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetPartThree.Business.Services
{
    public class EmployeeService: GenericBusinessService<Employee, int>, IEmployeeService
    {
        public EmployeeService(IGenericRepository<Employee, int> dataRepository) : base(dataRepository)
        {
        }

        public Employee GetEmployeeWithOrders(int employeeId, int currentPage, int pageSize)
        {
            using (var context = DataRepository.GetDbContext())
            {
                var employee = context.Set<Employee>()
                    .Include(x => x.Orders)
                    .ThenInclude(x => x.OrderDetails)
                    .First(x => x.EmployeeId == employeeId);

                if (employee != null)
                {
                    var orders = employee.Orders
                        .Skip((currentPage - 1) * pageSize)
                        .Take(pageSize);
                    employee.Orders = orders;
                    return employee;
                }

                return null;
            }  
        }        
    }
}