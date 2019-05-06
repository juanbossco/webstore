using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webstore.DataContext.Contracts;
using Webstore.DataContext;
using Webstore.Models;

namespace Webstore.Webservice.OrderApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderContext _orderCtx;

        public OrdersController(IOrderContext orderCtx)
        {
            this._orderCtx = orderCtx;
        }

        // GET api/orders
        [HttpGet("customer/{email}")]
        public ActionResult<IEnumerable<Order>> Get(string email)
        {
            var orders = _orderCtx.GetAll(email);
            return Ok(orders);
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = _orderCtx.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST api/orders
        // Create new Order
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order orderParam)
        {
            var order = new Order(orderParam.Customer, orderParam.Cart);
            _orderCtx.Add(order);
            return Ok(order);
        }

        // PUT api/orders/5
        // Update existing Order
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
        }

        // PUT api/orders/5
        [HttpPost("{id}")]
        public void Cancel(int id, [FromBody] string orderNumber)
        {
        }
    }
}
