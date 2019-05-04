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
using Webstore.DataContext;
using Webstore.DataContext.Contracts;

namespace Webstore.Test.Webservice
{
    public class OrderService
    {
        private readonly TestServer _server;
        private readonly ICartContext _cartContext;
        public OrderService()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Webstore.Webservice.OrderApi.Startup>());
            this._cartContext = new CartContext();
        }

        [Fact]
        public async Task CanPlaceOrder()
        {
            //Given a Customer with a not empty Cart

            var product = new Product(1, "cup", 10.5);
            var expectedQuantity = 3;

            var sessionId = new Guid().ToString();
            var cart = _cartContext.Get(sessionId);
            var cartProduct = new CartProduct(product, expectedQuantity);
            cart.Update(cartProduct);

            var customer = new Customer("Juan", "Lope", "juanbossco@gmail.com");

            //When

            var order = new Order(customer,cart);
            Order expectedOrder = null;

            var content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

            using (HttpClient client = _server.CreateClient())
            {
                var response = await client.PostAsync("api/orders/", content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                expectedOrder = JsonConvert.DeserializeObject<Order>(responseBody);
            }

            Assert.True(expectedOrder != null, "Order is null");
        }
    }
}