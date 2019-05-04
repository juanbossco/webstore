using Webstore.Webgateway.Clients.Contracts;
using Webstore.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Webstore.Webgateway.Clients
{
    public class CartClient : ICartClient
    {
        private readonly string _cartClientUrl = "http://localhost:5000/";

        public async Task<Cart> Get(string sessionId)
        {
            Cart result = null;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(_cartClientUrl + "api/cart" + sessionId);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Cart>(responseBody);
            }

            return result;
        }

        public async Task<Cart> Update(string sessionId, CartProduct cartProduct)
        {
            Cart cart = null;
            var content = new StringContent(JsonConvert.SerializeObject(cartProduct), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(_cartClientUrl + "api/cart/" + sessionId, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                cart = JsonConvert.DeserializeObject<Cart>(responseBody);
            }
            return cart;
        }
    }
}