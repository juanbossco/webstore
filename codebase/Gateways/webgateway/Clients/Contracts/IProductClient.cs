using Webstore.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Webstore.Webgateway.Clients.Contracts
{
    public interface IProductClient
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int productId);
    }
}