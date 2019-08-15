using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class TerritoryApiController : BaseApiController
    {
       protected readonly IGenericBusinessService<Territory, int> _territoryService;
        
        public TerritoryApiController(LinkGenerator linkGenerator,
                                      IGenericBusinessService<Territory, int> territoryService) : base(linkGenerator)
        {
            _territoryService = territoryService ?? throw new ArgumentNullException("territoryService");
        }

        [HttpGet]
        [Route("api/territory/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _territoryService.DataRepository.Get(id);
            var territory = TheModelFactory.Create(response);
            return Ok(territory);
        }

        [HttpGet]
        [Route("api/territory")]
        public IActionResult GetAll()
        {
            var response = _territoryService.DataRepository.GetAll();
            var territories = response.Select(x => TheModelFactory.Create(x));
            return Ok(territories);
        }        
    }
}