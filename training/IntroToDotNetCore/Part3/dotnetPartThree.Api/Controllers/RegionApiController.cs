using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class RegionApiController : BaseApiController
    {
        protected readonly IGenericBusinessService<Region, int> _regionService;
        
        public RegionApiController(LinkGenerator linkGenerator,
                                   IGenericBusinessService<Region, int> regionService) : base(linkGenerator)
        {
            _regionService = regionService ?? throw new ArgumentNullException("regionService");
        }

        [HttpGet]
        [Route("api/region/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _regionService.DataRepository.Get(id);
            var region = TheModelFactory.Create(response);
            return Ok(region);
        }

        [HttpGet]
        [Route("api/region")]
        public IActionResult GetAll()
        {
            var response = _regionService.DataRepository.GetAll();
            var regions = response.Select(x => TheModelFactory.Create(x));
            return Ok(regions);
        }        
    }
}