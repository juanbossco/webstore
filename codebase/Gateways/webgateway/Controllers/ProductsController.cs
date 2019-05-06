using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Webstore.Models;
using Newtonsoft.Json;
using System.Json;
using Webstore.Infrastructure.Clients;
using Webstore.Infrastructure.Clients.Contracts;

namespace Webstore.Webgateway.Controllers
{
    [Route("api/webstore/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductClient _productClient;
        public ProductsController(IProductClient productClient)
        {
            this._productClient = productClient;
        }

        // GET api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAll()
        {
            var result = await _productClient.Get();
            return Ok(result);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var result = await _productClient.Get(id);
            return Ok(result);
        }
    }
}
