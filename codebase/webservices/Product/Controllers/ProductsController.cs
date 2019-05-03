using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.db.Contracts;
using Product.Model;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDbProduct _dbProduct;

        public ProductsController(IDbProduct dbProduct)
        {
            this._dbProduct = dbProduct;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            return Ok(this._dbProduct.Get());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/products
        [HttpPost]
        public ActionResult<ProductModel> Post([FromBody] ProductModel product)
        {
            var result = this._dbProduct.Add(product.Name, product.Price);
            return Ok(result);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
