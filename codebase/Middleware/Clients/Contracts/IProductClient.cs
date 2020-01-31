using Webstore.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Webstore.Infrastructure.Clients.Contracts
{
    public interface IProductClient
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int productId);
    }
}