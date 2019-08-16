using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class OrderApiController : BaseApiController
    {
        protected readonly IGenericBusinessService<Order, int> _orderService;
        
        public OrderApiController(LinkGenerator linkGenerator,
                                  IGenericBusinessService<Order, int> orderService) : base(linkGenerator)
        {
            _orderService = orderService ?? throw new ArgumentNullException("orderService");
        }

        [HttpGet]
        [Route("api/order/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = _orderService.DataRepository.Get(id);
            var order = TheModelFactory.Create(response);
            return Ok(order);
        }

        [HttpGet]
        [Route("api/order")]
        public IActionResult GetAll()
        {
            var response = _orderService.DataRepository.GetAll();
            var orders = response.Select(x => TheModelFactory.Create(x));
            return Ok(orders);
        }        
    }
}