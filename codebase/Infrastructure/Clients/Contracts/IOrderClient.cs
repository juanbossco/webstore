using Webstore.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Webstore.Infrastructure.Clients.Contracts
{
    public interface IOrderClient
    {
         Task<Order> Post(Order order);
         Task<IEnumerable<Order>> Get(string email);
         Task<Order> Get(int orderId);
    }
}