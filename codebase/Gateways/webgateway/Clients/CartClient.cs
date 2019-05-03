using Webstore.Webgateway.Clients.Contracts;
using Webstore.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

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
                string responseBody = await client.GetStringAsync(_cartClientUrl + "api/cart" + sessionId);
                result = JsonConvert.DeserializeObject<Cart>(responseBody);
            }

            return result;
        }
    }
}