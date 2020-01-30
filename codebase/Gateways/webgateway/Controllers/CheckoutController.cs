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

namespace Webstore.Webgateway.Controllers
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
        [Route("{sessionId}")]
        public async Task<ActionResult<Order>> Post([FromBody] Customer customer, string sessionId)
        {
            var cart = await _cartClient.Get(sessionId);
            var order = new Order(customer, cart);
            order = await _orderClient.Post(order);
            //TODO replace below point-to-point integration with OrderPlaced event
            await _cartClient.Delete(sessionId);
            return Ok(order);
        }
    }
}