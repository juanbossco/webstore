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
using Webstore.Models;

namespace Webstore.Test.Webservice
{
    public class CartServiceTests
    {
        private readonly TestServer _server;
        public CartServiceTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Webstore.Webservice.CartApi.Startup>());
        }

        [Fact]
        public async Task CanGetCart()
        {
            Cart cart = null;
            //Given
            var sessionId = (new Guid()).ToString();
            //When
            using (HttpClient client = _server.CreateClient())
            {
                string responseBody = await client.GetStringAsync("api/cart/" + sessionId);
                cart = JsonConvert.DeserializeObject<Cart>(responseBody);
            }
            //Then
            Assert.True(cart != null);
            Assert.True(cart.SessionId == sessionId);
        }

        [Fact]
        public async Task CanUpdateCart()
        {
            //Given
            Cart cart = null;
            var sessionId = (new Guid()).ToString();
            var product = new Product(1, "cup", 10.5);
            var expectedQuantity = 3;
            var cartProduct = new CartProduct(product, expectedQuantity);

            //When
            var content = new StringContent(JsonConvert.SerializeObject(cartProduct), Encoding.UTF8, "application/json");
            using (HttpClient client = _server.CreateClient())
            {
                var response = await client.PostAsync("api/cart/" + sessionId, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                cart = JsonConvert.DeserializeObject<Cart>(responseBody);
            }
            
            //Then
            Assert.True(cart != null, "Cart is null");
            Assert.True(cart.Products.Count() > 0, "No Products were added");
            var expectedProduct = cart.Products.First();
            Assert.True(expectedProduct.Quantity == expectedQuantity, "Product Quantity was not updated");
        }
    }
}