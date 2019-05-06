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
using System.Text;
using System.Linq;
using Webstore.Models;
using Webstore.Infrastructure;

namespace Webstore.Test.Gateways
{
    public class WebGatewayTests
    {
        private readonly TestServer _server;
        public WebGatewayTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Webstore.Webgateway.Startup>());
        }

        [Fact]
        public async Task CanGetProduct()
        {
            Webstore.Models.Product product = null;
            using (HttpClient client = _server.CreateClient())
            {
                product = await ServiceClient.GetAsync<Webstore.Models.Product>(client, "api/webstore/products/1");
            }
            Assert.True(product != null);
        }

        [Fact]
        public async Task CanGetCart()
        {
            //Given
            var sessionId = Guid.NewGuid().ToString();
            Cart cart = null;
            //When
            using (HttpClient client = _server.CreateClient())
            {
                cart = await ServiceClient.GetAsync<Cart>(client, "api/webstore/cart/" + sessionId);
            }
            //Then
            Assert.True(cart != null);
        }

        [Fact]
        public async Task CanUpdateCart()
        {
            //Given
            Cart cart = null;
            var sessionId = (new Guid()).ToString();
            var expectedQuantity = 3;
            var cartProduct = new { ProductId = 1, Quantity = 3 };

            //When
            using (HttpClient client = _server.CreateClient())
            {
                cart = await ServiceClient.PostAsync<Cart>(client, "api/webstore/cart/" + sessionId, cartProduct);
                cart = await ServiceClient.GetAsync<Cart>(client, "api/webstore/cart/" + sessionId);
            }

            //Then
            Assert.True(cart != null, "Cart is null");
            Assert.True(cart.Products.Count() > 0, "No Products were added");
            var expectedProduct = cart.Products.First();
            Assert.True(expectedProduct.Quantity == expectedQuantity, "Product Quantity was not updated");
        }

        [Fact]
        public async Task CanCheckout()
        {
            //Given
            var sessionId = (new Guid()).ToString();
            var customer = new { FirstName = "Juan", LastName = "Lopez", Email = "juanbossco@gmail.com" };
            Order order = null;
            //When
            using (HttpClient client = _server.CreateClient())
            {
                order = await ServiceClient.PostAsync<Order>(client, "api/checkout/" + sessionId, customer);
            }
            //Then
            Assert.True(order != null);
        }
    }
}
