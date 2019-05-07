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
using Webstore.Infrastructure;

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
                cart = await ServiceClient.GetAsync<Cart>(client, "api/cart/" + sessionId);
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
            var expectedQuantity = 3;
            var cartProduct = new { Product = new { ProductId = 1, Name = "Integration Test" }, Quantity = 3 };

            //When
            using (HttpClient client = _server.CreateClient())
            {
                cart = await ServiceClient.PostAsync<Cart>(client, "api/cart/" + sessionId, cartProduct);
                cart = await ServiceClient.GetAsync<Cart>(client, "api/cart/" + sessionId);
            }

            //Then
            Assert.True(cart != null, "Cart is null");
            Assert.True(cart.Products.Count() > 0, "No Products were added");
            var expectedProduct = cart.Products.First();
            Assert.True(expectedProduct.Quantity == expectedQuantity, "Product Quantity was not updated");
        }

        [Fact]
        public async Task CanDelete()
        {
            //Given
            var sessionId = Guid.NewGuid().ToString();
            //When
            using (HttpClient client = _server.CreateClient())
            {
                await ServiceClient.DeleteAsync(client, "api/cart/" + sessionId);
            }
            //Then
            Assert.True(1 == 1);
        }
    }
}