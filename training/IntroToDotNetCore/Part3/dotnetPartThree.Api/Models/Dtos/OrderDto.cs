using System;
using System.Collections.Generic;

namespace dotnetPartThree.Api.Models.Dtos
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderDetailDtos = new List<OrderDetailDto>();
        }
        
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string Url { get; set; }
        public IEnumerable<OrderDetailDto> OrderDetailDtos { get; set; }        
    }
}