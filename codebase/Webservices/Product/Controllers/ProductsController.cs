﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webstore.DataContext.Contracts;
using Webstore.DataContext;

namespace Webstore.Webservice.ProductApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductContext _dbProduct;

        public ProductsController(IProductContext dbProduct)
        {
            this._dbProduct = dbProduct;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Webstore.Models.Product>> Get()
        {
            return Ok(this._dbProduct.Get());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var products = this._dbProduct.Get();
            var product = products.SingleOrDefault(p => p.ProductId == id);
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Webstore.Models.Product> Post([FromBody] IEnumerable<Webstore.Models.Product> products)
        {
            var result = new List<Webstore.Models.Product>();
            foreach (var product in products)
            {
                result.Add(this._dbProduct.Add(product.Name, product.Price));
            }
            return Ok(result);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Webstore.Models.Product product)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
