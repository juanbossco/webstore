using Webstore.Models;
using Webstore.Webgateway.Clients.Contracts;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Webstore.Webgateway.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly string _orderClientUrl = "";
        public async Task<Order> Post(Order order)
        {
            Order result = null;

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_orderClientUrl + "api/orders", content);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<Order>(responseString);
            }

            return result;
        }
    }
}