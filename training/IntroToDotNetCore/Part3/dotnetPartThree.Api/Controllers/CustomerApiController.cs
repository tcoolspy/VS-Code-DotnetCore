using System;
using System.Linq;
using dotnetPartThree.Business.Contracts;
using dotnetPartThree.Core.Framework.Extensions;
using dotnetPartThree.Core.Framework.Enums;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace dotnetPartThree.Api.Controllers
{
    public class CustomerApiController : BaseApiController
    {
       protected readonly ICustomerService _customerSevice;
        
        public CustomerApiController(LinkGenerator linkGenerator,
                                     ICustomerService customerSevice) : base(linkGenerator)
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

       /// <summary>
        /// Retrieves filtered customer records based on one or more criteria
        /// </summary>
        /// <param name="CompanyName">Search by Company Name.  Includes all or a portion of the name.</param>
        /// <param name="ContactName">Search by Contact Name.  Includes all or a portion of the name.</param>
        /// <param name="ContactTitle">Search by Contact Title.  Includes all or a portion of the title.</param>
        /// <param name="City">Search by City.  Includes all or a portion of the city name.</param>
        /// <param name="Country">Search by country.  Includes all or a portion of the country name.</param>
        /// <param name="PostalCode">Search by postal code.  Includes all or a portion of the code.</param>
        /// <param name="SearchCriteriaOperator">Determines whether search results inlclude all or any of the search criteria (see remarks). This parameter is used when mulitple search criteria are specified.</param>
        /// <returns></returns>
        /// <remarks>For the 'SearchCriteriaInclude' parameter, you can do one of two things.
        /// If you want to narrow your search when all of the specified
        /// search criteria are met, use the 'all' keyword.
        /// If you want to narrow your search when any of the specified
        /// search criteria are met, use the 'any' keyword.
        /// For example, if you include a CompanyName and ContactTitle and specify, 'all', only records that match the CompanyName AND
        /// the ContactTitle will be returned.  If you specify 'any', records that include the company name OR the contact title
        /// will be returned.  'All' will return a more narrow list of results than 'Any' in most scenarios.
        /// </remarks>
        [HttpGet]
        [Route("api/customer/filter")]
        public IActionResult GetFiltered(string CompanyName = null,
                                         string ContactName = null,
                                         string ContactTitle = null,
                                         string City = null,
                                         string Country = null,
                                         string PostalCode = null,
                                         string SearchCriteriaOperator = "any")
        {
            var queryParams = this.HttpContext.Request.Query.ToList();
            if (queryParams.Any())
            {
                if (queryParams.Count > 0) // NOTE: this check is only needed for strongly-type searches
                {
                    // logic to do multiple attribute search
                    IQueryable<Customer> searchResponse = _customerSevice.DataRepository.GetAll();
                    var searchTerms = queryParams.Where(x => x.Key == "SearchCriteriaOperator").ToDictionary(x => x.Key, x => x.Value);
                    switch (SearchCriteriaOperator.ToLower())
                    {
                        case "all":
                            var allSearchResults = searchResponse.SearchBy(searchTerms, LambdaLogicalOp.And).ToList();
                            return Ok(allSearchResults);
                        case "any":
                            var anySearchResults = searchResponse.SearchBy(searchTerms, LambdaLogicalOp.Or).ToList();
                            return Ok(anySearchResults);
                        default:
                            var searchResults = searchResponse.SearchBy(searchTerms, LambdaLogicalOp.Or).ToList();
                            return Ok(searchResults);
                    }
                }

                var param = queryParams.FirstOrDefault().Value.ToString();
                var key = this.HttpContext.Request.Query.Keys.ToList().FirstOrDefault();
                if (key != "SearchCriteriaOperator")
                {
                    IQueryable<Customer> response;
                    var sortedResponse = new List<Customer>();
                    switch (key)
                    {
                        case "CompanyName":
                            response = _customerSevice.DataRepository.GetAll(x => x.CompanyName.ToLower().Contains(param.ToLower()));                            
                            return Ok(response.Select(x => TheModelFactory.Create(x)));
                        case "ContactName":
                            response = _customerSevice.DataRepository.GetAll(x => x.ContactName.ToLower().Contains(param.ToLower()));
                            return Ok(response.Select(x => TheModelFactory.Create(x)));                    
                        case "ContactTitle":                        
                            response = _customerSevice.DataRepository.GetAll(x => x.ContactTitle.ToLower().Contains(param.ToLower()));
                            //sortedResponse = response.SortBy(x => x.ContactName, OrderBy.Ascending).ToList();
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
                else
                {
                    return BadRequest("No valid search criteria have been provided.");
                }
            }
            return NotFound();
        }    


        [HttpGet]
        [Route("api/customer/filterterm")]
        public IActionResult GetFilteredTerm(string searchTerm)
        {
            var queryParams = this.HttpContext.Request.Query.ToList();
            if (queryParams.Any())
            {
                IQueryable<Customer> searchResponse = _customerSevice.DataRepository.GetAll();
                var key = this.HttpContext.Request.Query.Keys.ToList().FirstOrDefault();
                if (key == "searchTerm")
                {
                    var param = queryParams.FirstOrDefault().Value.ToString();
                    var response = searchResponse.SearchByMultiple(searchTerm);
                    return Ok(response.Select(x => TheModelFactory.Create(x)));
                }
                else return BadRequest("No valid search criteria have been provided.");

            }
            else
            {
                return BadRequest("No valid search criteria have been provided.");
            }
        }            
    }
}