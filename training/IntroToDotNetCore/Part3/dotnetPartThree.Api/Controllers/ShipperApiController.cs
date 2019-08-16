using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class ShipperApiController : BaseApiController
    {
        protected readonly IGenericBusinessService<Shipper, int> _shipperService;
        
        public ShipperApiController(LinkGenerator linkGenerator,
                                    IGenericBusinessService<Shipper, int> shipperService) : base(linkGenerator)
        {
            _shipperService = shipperService ?? throw new ArgumentNullException("shipperService");
        }

        [HttpGet]
        [Route("api/shipper/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _shipperService.DataRepository.Get(id);
            var shipper = TheModelFactory.Create(response);
            return Ok(shipper);
        }

        [HttpGet]
        [Route("api/shipper")]
        public IActionResult GetAll()
        {
            var response = _shipperService.DataRepository.GetAll();
            var shippers = response.Select(x => TheModelFactory.Create(x));
            return Ok(shippers);
        }      
    }
}