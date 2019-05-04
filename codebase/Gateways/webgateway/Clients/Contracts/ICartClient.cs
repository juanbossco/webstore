using Webstore.Models;
using System.Threading.Tasks;

namespace Webstore.Webgateway.Clients.Contracts
{
    public interface ICartClient
    {
         Task<Cart> Get(string sessionId);
         Task<Cart> Update(string sessionId, CartProduct product);
    }
}