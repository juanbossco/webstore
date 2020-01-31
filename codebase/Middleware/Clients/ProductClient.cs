using Webstore.Models;
using Webstore.Infrastructure.Clients.Contracts;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Webstore.Infrastructure;

namespace Webstore.Infrastructure.Clients
{
    public class ProductClient : IProductClient
    {
        private readonly string _productServiceUrl = "https://webstore-productapi.azurewebsites.net/api/products/";
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