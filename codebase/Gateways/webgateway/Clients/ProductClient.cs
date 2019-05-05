using Webstore.Models;
using Webstore.Webgateway.Clients.Contracts;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Webstore.Infrastructure;

namespace Webstore.Webgateway.Clients
{
    public class ProductClient : IProductClient
    {
        private readonly string _productServiceUrl = "http://localhost:8000/api/products/";
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await ServiceClient.GetAsync<IEnumerable<Product>>(_productServiceUrl);
            return products;
        }

        public async Task<Product> Get(int productId)
        {
            var product = await ServiceClient.GetAsync<Product>(_productServiceUrl + productId.ToString());
            return product;
        }
    }
}