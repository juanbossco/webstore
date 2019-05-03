using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Webstore.Models;
using Newtonsoft.Json;
using System.Json;

namespace Webgateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private string _productClientUrl = "http://localhost:5000/";
        public ProductsController()
        {

        }
        // GET api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            IEnumerable<Product> result = null;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string responseBody = await client.GetStringAsync(_productClientUrl + "api/products");
                    result = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Exception in Product gateway Get Products!");
                    Console.WriteLine("\nMessage :{0} ", e.Message);
                }
            }
            return Ok(result);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            Product result = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string responseBody = await client.GetStringAsync(_productClientUrl + "api/products/" + id.ToString());
                    result = JsonConvert.DeserializeObject<Product>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Exception in Product gateway Get Product!");
                    Console.WriteLine("\nMessage :{0} ", e.Message);
                }
            }

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
