using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Webstore.Models;
using Newtonsoft.Json;
using System.Json;
using Webstore.Infrastructure.Clients.Contracts;
using Webstore.Infrastructure.Clients;
using Webstore.Gateway.Dto;

namespace Webstore.Webgateway.Controllers
{
    [Route("api/webstore/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderClient _orderClient;
        public OrdersController(IOrderClient orderClient)
        {
            this._orderClient = orderClient;
        }

        // GET api/orders
        [HttpGet("customer/{email}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(string email)
        {
            var orders = await _orderClient.Get(email);
            return Ok(orders);
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _orderClient.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }
    }
}