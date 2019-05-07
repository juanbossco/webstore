using Webstore.Models;
using Webstore.Infrastructure.Clients.Contracts;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Webstore.Infrastructure;


namespace Webstore.Infrastructure.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly string _orderClientUrl = "https://webstore-orderapi.azurewebsites.net/api/orders/";

        public async Task<IEnumerable<Order>> Get(string email)
        {
            var result = await ServiceClient.GetAsync<IEnumerable<Order>>(_orderClientUrl + email);
            return result;
        }

        public async Task<Order> Get(int orderId)
        {
            var result = await ServiceClient.GetAsync<Order>(_orderClientUrl + orderId.ToString());
            return result;
        }

        public async Task<Order> Post(Order order)
        {
            var result = await ServiceClient.PostAsync<Order>(_orderClientUrl, order);
            return result;
        }
    }
}