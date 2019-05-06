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
    public class CartController : ControllerBase
    {
        private readonly ICartClient _cartClient;
        private readonly IProductClient _productClient;

        public CartController(
            ICartClient cartClient,
            IProductClient productClient)
        {
            this._cartClient = cartClient;
            this._productClient = productClient;
        }

        [HttpGet("{sessionId}")]
        public async Task<ActionResult<Cart>> Get(string sessionId)
        {
            var cart = await _cartClient.Get(sessionId);
            return Ok(cart);
        }

        [HttpPost("{sessionId}")]
        public async Task<ActionResult<Cart>> Post([FromBody] CartProductDto cartProductDto, string sessionId)
        {
            var product = await _productClient.Get(cartProductDto.ProductId);

            if (product == null)
                return BadRequest("Product does not exist.");

            if (cartProductDto.Quantity < 1)
                return BadRequest("Quantity cannot be less than 0");

            var cartProduct = new CartProduct(product, cartProductDto.Quantity);
            var cart = await _cartClient.Update(sessionId, cartProduct);

            return Ok(cart);
        }
    }
}