using System;
using System.Linq;
using dotnetPartThree.Business.Contracts;
using dotnetPartThree.Core.Framework.Extensions;
using dotnetPartThree.Core.Framework.Enums;
using dotnetPartThree.Core.Models;
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

        [HttpGet]
        [Route("api/customer/filter")]
        public IActionResult GetFiltered(string CompanyName = null,
                                         string ContactName = null,
                                         string ContactTitle = null,
                                         string City = null,
                                         string Country = null,
                                         string PostalCode = null)
        {
            var queryParams = this.HttpContext.Request.Query.ToList();
            if (queryParams.Any())
            {
                if (queryParams.Count > 1)
                {
                    // logic to do multiple attribute search
                    IQueryable<Customer> searchResponse = _customerSevice.DataRepository.GetAll();
                    var searchTerms = queryParams.ToDictionary(x => x.Key, x => x.Value);
                    var searchResults = searchResponse.SearchBy(searchTerms).ToList();

                    return Ok(searchResults);
                }

                var param = queryParams.FirstOrDefault().Value.ToString();
                var key = this.HttpContext.Request.Query.Keys.ToList().FirstOrDefault();
                IQueryable<Customer> response;
                switch (key)
                {
                    case "CompanyName":
                        response = _customerSevice.DataRepository.GetAll(x => x.CompanyName.ToLower().Contains(param.ToLower()));
                        //var sortedList = response.SortBy("CompanyName", OrderBy.Ascending);
                        //var sortedList = response.SortBy(x => x.CompanyName, OrderBy.Ascending);
                        //var search = response.SearchBy("Gourmet", "CompanyName");
                        //var search = response.SearchBy("Gourmet", x => x.CompanyName);
                        return Ok(response.Select(x => TheModelFactory.Create(x)));
                    case "ContactName":
                        response = _customerSevice.DataRepository.GetAll(x => x.ContactName.ToLower().Contains(param.ToLower()));
                        return Ok(response.Select(x => TheModelFactory.Create(x)));                    
                    case "ContactTitle":
                        response = _customerSevice.DataRepository.GetAll(x => x.ContactTitle.ToLower().Contains(param.ToLower()));
                        return Ok(response.Select(x => TheModelFactory.Create(x)));
                    case "City":
                        response = _customerSevice.DataRepository.GetAll(x => x.City.ToLower().Contains(param.ToLower()));
                        return Ok(response.Select(x => TheModelFactory.Create(x)));                    
                    case "Country":
                        response = _customerSevice.DataRepository.GetAll(x => x.Country.ToLower().Contains(param.ToLower()));
                        return Ok(response.Select(x => TheModelFactory.Create(x)));
                    case "PostalCode":
                        response = _customerSevice.DataRepository.GetAll(x => x.PostalCode.ToLower().Contains(param.ToLower()));
                        return Ok(response.Select(x => TheModelFactory.Create(x)));
                }
            }
            return NotFound();
        }        
    }
}