using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class ProductApiController : BaseApiController
    {
        protected readonly IGenericBusinessService<Product, int> _productService;

        public ProductApiController(LinkGenerator linkGenerator,
                                    IGenericBusinessService<Product, int> productService) : base(linkGenerator)
        {
            _productService = productService ?? throw new ArgumentNullException("productService");
        }

        [HttpGet]
        [Route("api/product/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _productService.DataRepository.Get(id);
            var product = TheModelFactory.Create(response);
            return Ok(product);
        }

        [HttpGet]
        [Route("api/product")]
        public IActionResult GetAll()
        {
            var response = _productService.DataRepository.GetAll();
            var products = response.Select(x => TheModelFactory.Create(x));
            return Ok(products);
        }        
    }
}