using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Webstore.Models;
using Newtonsoft.Json;
using System.Json;
using Webstore.Webgateway.Clients.Contracts;
using Webstore.Webgateway.Clients;

namespace Webgateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICartClient _cartClient;
        private readonly IOrderClient _orderClient;

        public CheckoutController(ICartClient cartClient, IOrderClient orderClient)
        {
            this._cartClient = cartClient;
            this._orderClient = orderClient;
        }

        [HttpPost]
        [Route("api/[controller]/sessionId")]
        public async Task<ActionResult<Order>> Post([FromBody] Customer customer, string sessionId)
        {
            var cart = await _cartClient.Get(sessionId);
            var order = new Order(customer,cart);
            await _orderClient.Post(order);
            return Ok(order);
        }
    }
}