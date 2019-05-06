using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webstore.Models;
using Webstore.DataContext.Contracts;
using Webstore.DataContext;
using Webstore.Infrastructure;
using Webstore.Infrastructure.Clients.Contracts;

namespace Webstore.Webservice.CartApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartContext _cartCtxt;

        public CartController(ICartContext cartCtx)
        {
            this._cartCtxt = cartCtx;
        }

        // GET api/cart/abc
        [HttpGet("{sessionId}")]
        public ActionResult<Cart> Get(string sessionId)
        {
            var cart = _cartCtxt.Get(sessionId);
            return cart;
        }

        // POST api/cart
        // For testing purposes the session Id is passed in the query string
        [HttpPost("{sessionId}")]
        public ActionResult<Cart> Post([FromBody] CartProduct cartProduct, string sessionId)
        {
            var cart = _cartCtxt.Get(sessionId);
            cart.Update(cartProduct);
            return Ok(cart);
        }

        // DELETE api/cart/5
        [HttpDelete("{sessionId}")]
        public void Delete([FromBody] Cart cart, string sessionId)
        {
            _cartCtxt.Delete(sessionId);
        }
    }
}
