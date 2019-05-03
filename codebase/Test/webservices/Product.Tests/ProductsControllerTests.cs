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

namespace Product.Tests
{
    public class ProductsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public ProductsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Webservice.Product.Startup>());
            _client = _server.CreateClient();

        }

        [Fact]
        public async Task CanGetProducts()
        {
            var response = await _client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Webstore.Models.Product>>(responseString);
            Assert.False(string.IsNullOrEmpty(responseString));
        }

        [Fact]
        public async Task CanAddProduct()
        {
            var product = JsonConvert.SerializeObject(new { Name = "abcd", Price = 10.5 });
            var content = new StringContent(product.ToString(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/products", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Webstore.Models.Product>(responseString);
            Assert.True(result.ProductId == 1);
            Assert.True(result.Name == "abcd");
            Assert.True(result.Price == 10.5);
        }

        [Fact]
        public async Task AddAndGetProduct()
        {
            //Given
            var product = JsonConvert.SerializeObject(new { Name = "abcd", Price = 10.5 });
            var content = new StringContent(product.ToString(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/products", content);
            response.EnsureSuccessStatusCode();
            //When
            response = await _client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Webstore.Models.Product>>(responseString);
            //Then
            var newProduct = result.FirstOrDefault();
            Assert.NotNull(newProduct);
            Assert.True(newProduct.ProductId == 1);
            Assert.True(newProduct.Name == "abcd");
            Assert.True(newProduct.Price == 10.5);
        }
    }
}