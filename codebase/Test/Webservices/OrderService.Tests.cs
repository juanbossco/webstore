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
using Webstore.Infrastructure;

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

            var order = new Order(customer, cart);
            Order expectedOrder = null;
            IEnumerable<Order> customerOrders = null;

            using (HttpClient client = _server.CreateClient())
            {
                expectedOrder = await ServiceClient.PostAsync<Order>(client, "api/orders/", order);
                expectedOrder = await ServiceClient.GetAsync<Order>(client, "api/orders/1");
                customerOrders = await ServiceClient.GetAsync<IEnumerable<Order>>(client, "api/orders/?email=juanbossco@gmail.com");
            }

            Assert.True(expectedOrder != null, "Order is null");
            Assert.True(customerOrders != null, "Customer Orders is empy");
        }
    }
}