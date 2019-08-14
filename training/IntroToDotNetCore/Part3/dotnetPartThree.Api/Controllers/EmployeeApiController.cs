using System;
using System.Linq;
using dotnetPartThree.Business.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class EmployeeApiController : BaseApiController
    {
        protected readonly IEmployeeService _employeeService;
        
        public EmployeeApiController(LinkGenerator linkGenerator,
                                    IEmployeeService employeeService) : base(linkGenerator)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException("employeeService");
        }

        [HttpGet]
        [Route("api/employee/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _employeeService.GetEmployeeWithOrders(id, 1, 5);
            //var response = _employeeService.DataRepository.GetIncluding(x => x.EmployeeId == id, 
//                y => y.Orders,
//                y => y.EmployeeTerritories, y => y.InverseReportsToNavigation);
            var employee = TheModelFactory.Create(response);
            return Ok(employee);
        }

        [HttpGet]
        [Route("api/employee")]
        public IActionResult GetAll()
        {
            var response = _employeeService.DataRepository.GetAll();
            var employees = response.Select(x => TheModelFactory.Create(x));
            return Ok(employees);
        }        
    }
}