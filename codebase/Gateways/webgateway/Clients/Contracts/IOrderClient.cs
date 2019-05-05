using Webstore.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Webstore.Webgateway.Clients.Contracts
{
    public interface IOrderClient
    {
         Task<Order> Post(Order order);
         Task<IEnumerable<Order>> Get(string email);
    }
}