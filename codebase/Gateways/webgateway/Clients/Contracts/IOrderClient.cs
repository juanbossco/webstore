using Webstore.Models;
using System.Threading.Tasks;

namespace Webstore.Webgateway.Clients.Contracts
{
    public interface IOrderClient
    {
         Task<Order> Post(Order order);
    }
}