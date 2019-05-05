using Webstore.Webgateway.Clients.Contracts;
using Webstore.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Webstore.Infrastructure;

namespace Webstore.Webgateway.Clients
{
    public class CartClient : ICartClient
    {
        private readonly string _cartClientUrl = "http://localhost:6000/api/cart/";

        public async Task<Cart> Get(string sessionId)
        {
            var result = await ServiceClient.GetAsync<Cart>(_cartClientUrl + sessionId);
            return result;
        }

        public async Task<Cart> Update(string sessionId, CartProduct cartProduct)
        {
            var result = await ServiceClient.PostAsync<Cart>(_cartClientUrl + sessionId, cartProduct);
            return result;
        }
    }
}