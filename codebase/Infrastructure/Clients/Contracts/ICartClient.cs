using Webstore.Models;
using System.Threading.Tasks;

namespace Webstore.Infrastructure.Clients.Contracts
{
    public interface ICartClient
    {
        Task<Cart> Get(string sessionId);
        Task<Cart> Update(string sessionId, CartProduct product);
        Task Delete(string sessionId);
    }
}