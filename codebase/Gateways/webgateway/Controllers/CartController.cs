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
    public class CartController : ControllerBase
    {
        private readonly ICartClient _cartClient;

        public CartController(ICartClient cartClient)
        {
            this._cartClient = cartClient;
        }

        [HttpGet("{sessionId}")]
        public async Task<ActionResult<Cart>> Get(string sessionId)
        {
            var cart = await _cartClient.Get(sessionId);
            return Ok(cart);
        }

        [HttpPost("{sessionId}")]
        public async Task<ActionResult<Cart>> Post([FromBody] CartProduct product, string sessionId)
        {
            if (product.Quantity < 1)
                return BadRequest("Quantity cannot be less than 0");
            var cart = await _cartClient.Update(sessionId, product);
            return Ok(cart);
        }
    }
}