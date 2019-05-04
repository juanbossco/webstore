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
        //private readonly HttpClient _client;
        public CartServiceTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Webstore.Webservice.CartApi.Startup>());
            //_client = _server.CreateClient();

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
    }
}