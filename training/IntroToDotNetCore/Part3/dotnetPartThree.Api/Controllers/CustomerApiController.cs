using System;
using System.Linq;
using dotnetPartThree.Business.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class CustomerApiController : BaseApiController
    {
       protected readonly ICustomerBusinessService _customerSevice;
        
        public CustomerApiController(LinkGenerator linkGenerator,
                                     ICustomerBusinessService customerSevice) : base(linkGenerator)
        {
            _customerSevice = customerSevice ?? throw new ArgumentNullException("customerService");
        }

        /// <summary>
        /// Retrieves a Customer based on Customer Id
        /// </summary>
        /// <param name="id">The id of the Customer</param>
        /// <returns>An entity of type Customer</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     api/customer/1
        ///
        /// </remarks> 
        [HttpGet]
        [Route("api/customer/{id}")]
        public IActionResult Get(string id)
        {
            var response = _customerSevice.GetCustomerWithOrders(id);
            //var response = _customerSevice.DataRepository.GetIncluding(x => x.CustomerId == id, y => y.Orders);
            var customer = TheModelFactory.Create(response);
            return Ok(customer);
        }

        /// <summary>
        /// Retrieves all Customer records.
        /// </summary>
        /// <returns>A list of Customer records.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     api/customer
        ///
        /// </remarks> 
        [HttpGet]
        [Route("api/customer")]
        public IActionResult GetAll()
        {
            var response = _customerSevice.DataRepository.GetAllIncluding(true, x => x.Orders);
            var customers = response.Select(x => TheModelFactory.Create(x));
            return Ok(customers);
        }        
    }
}