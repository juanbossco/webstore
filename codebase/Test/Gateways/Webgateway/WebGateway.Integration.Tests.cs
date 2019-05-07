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
    public class WebGatewayIntegrationTests
    {
        private readonly string gatewayUrl = string.Empty;
        private readonly string sessionId = string.Empty;

        public WebGatewayIntegrationTests()
        {
            gatewayUrl = "https://webstore-gatewayapi.azurewebsites.net/";
            sessionId = "A1B2C3IT";
        }

        [Fact]
        public async Task CanAddProducts()
        {
            IEnumerable<Webstore.Models.Product> products = null;
            //Given
            var body = new[]
            {
                new
                {
                    Name= "AFRICAN TEA",
                    Price= "7.5",
                    Properties= new []
                    {
                        new
                        {
                            Property= new {
                                Name= "Count",
                                Type= "int"
                            },
                            Value= 15
                        }
                    }
                }
            };
            //When
            products = await ServiceClient.PostAsync<IEnumerable<Webstore.Models.Product>>("https://webstore-productapi.azurewebsites.net/api/products/", body);

            //Then
            Assert.True(products != null);
        }

        [Fact]
        public async Task CanGetAllProducts()
        {
            //Given
            IEnumerable<Webstore.Models.Product> products = null;
            //When
            products = await ServiceClient.GetAsync<IEnumerable<Webstore.Models.Product>>(gatewayUrl + "api/webstore/products/");
            //Then
            Assert.True(products != null);
        }

        [Fact]
        public async Task CanGetProduct()
        {
            Webstore.Models.Product product = null;
            product = await ServiceClient.GetAsync<Webstore.Models.Product>(gatewayUrl + "api/webstore/products/1");
            Assert.True(product != null);
        }

        [Fact]
        public async Task CanGetCart()
        {
            //Given
            Cart cart = null;
            //When
            cart = await ServiceClient.GetAsync<Cart>(gatewayUrl + "api/webstore/cart/" + sessionId);
            //Then
            Assert.True(cart != null);
        }

        [Fact]
        public async Task CanUpdateCart()
        {
            //Given
            Cart cart = null;
            var expectedQuantity = 3;
            var cartProduct = new { ProductId = 1, Quantity = 3 };

            //When
            cart = await ServiceClient.PostAsync<Cart>(gatewayUrl + "api/webstore/cart/" + sessionId, cartProduct);
            cart = await ServiceClient.GetAsync<Cart>(gatewayUrl + "api/webstore/cart/" + sessionId);

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
            var customer = new { FirstName = "Juan", LastName = "Lopez", Email = "juanbossco@gmail.com" };
            Order order = null;
            //When
            order = await ServiceClient.PostAsync<Order>(gatewayUrl + "api/checkout/" + sessionId, customer);
            //Then
            Assert.True(order != null);
        }

        [Fact(Skip="Not Ready")]
        public async Task CanGetCustomerOrders()
        {
            //Given
            var customerEmail = "juanbossco@gmail.com";
            //When
            var orders = await ServiceClient.GetAsync<IEnumerable<Order>>(gatewayUrl + "/api/webstore/orders/customer/" + customerEmail);
            //Then
            Assert.True(orders != null);
            Assert.True(orders.Any());
        }
    }
}
