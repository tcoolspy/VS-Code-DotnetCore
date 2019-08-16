using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class SupplierApiController : BaseApiController
    {
        protected readonly IGenericBusinessService<Supplier, int> _supplierService;
        
        public SupplierApiController(LinkGenerator linkGenerator,
                                     IGenericBusinessService<Supplier, int> supplierService) : base(linkGenerator)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException("supplierService");
        }

        [HttpGet]
        [Route("api/supplier/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _supplierService.DataRepository.Get(id);
            var supplier = TheModelFactory.Create(response);
            return Ok(supplier);
        }

        [HttpGet]
        [Route("api/supplier")]
        public IActionResult GetAll()
        {
            var response = _supplierService.DataRepository.GetAll();
            var suppliers = response.Select(x => TheModelFactory.Create(x));
            return Ok(suppliers);
        }        
    }
}