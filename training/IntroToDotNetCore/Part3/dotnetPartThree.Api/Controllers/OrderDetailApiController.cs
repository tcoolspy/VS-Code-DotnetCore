using System;
using System.Linq;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class OrderDetailApiController : BaseApiController
    {
        protected readonly IGenericBusinessService<OrderDetail, int> _orderDetailService;
        
        public OrderDetailApiController(LinkGenerator linkGenerator,
                                        IGenericBusinessService<OrderDetail, int> orderDetailService) : base(linkGenerator)
        {
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException("orderDetailService");
        }

        [HttpGet]
        [Route("api/orderdetail/{orderId:int}/{productId:int}")]
        public IActionResult Get(int orderId, int productId)
        {
            var response = _orderDetailService.DataRepository.Get(orderId, productId);
            var orderDetail = TheModelFactory.Create(response);
            return Ok(orderDetail);
        }

        [HttpGet]
        [Route("api/orderdetail")]
        public IActionResult GetAll()
        {
            var response = _orderDetailService.DataRepository.GetAll();
            var orderDetails = response.Select(x => TheModelFactory.Create(x));
            return Ok(orderDetails);
        }        
    }
}