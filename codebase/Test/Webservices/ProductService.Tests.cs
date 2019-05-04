using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Json;
using System.Text;
using System.Linq;
using Webstore.Infrastructure;

namespace Webstore.Test.Webservice
{
    public class ProductsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public ProductsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Webstore.Webservice.ProductApi.Startup>());
            _client = _server.CreateClient();

        }

        [Fact]
        public async Task CanGetProducts()
        {
            IEnumerable<Webstore.Models.Product> products = null;

            using (HttpClient client = _server.CreateClient())
            {
                products = await ServiceClient.GetAsync<IEnumerable<Webstore.Models.Product>>(client, "/api/products");
            }

            Assert.True(products != null, "Failed to get Products");
        }

        [Fact]
        public async Task CanAddProduct()
        {
            var product = new { Name = "abcd", Price = 10.5 };
            Webstore.Models.Product result = null;

            using (HttpClient client = _server.CreateClient())
            {
                result = await ServiceClient.PostAsync<Webstore.Models.Product>(client, "/api/products", product);
            }

            Assert.True(result != null);
            Assert.True(result.ProductId == 1);
            Assert.True(result.Name == "abcd");
            Assert.True(result.Price == 10.5);
        }

        [Fact]
        public async Task AddAndGetProduct()
        {
            //Given a new Product
            var product = new Webstore.Models.Product(1, "cup", 10.5);
            //When the Product is added
            using (HttpClient client = _server.CreateClient())
            {
                product = await ServiceClient.PostAsync<Webstore.Models.Product>(client, "/api/products", product);
            }
            //AND calling to get all products
            IEnumerable<Webstore.Models.Product> products = null;

            using (HttpClient client = _server.CreateClient())
            {
                products = await ServiceClient.GetAsync<IEnumerable<Webstore.Models.Product>>(client, "/api/products");
            }

            //Then
            Assert.NotNull(products);
            var newProduct = products.FirstOrDefault();
            Assert.NotNull(newProduct);
            Assert.True(newProduct.ProductId == 1);
            Assert.True(newProduct.Name == "cup", "Product name doest not match");
            Assert.True(newProduct.Price == 10.5);
        }
    }
}