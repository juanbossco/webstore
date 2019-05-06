using System.Collections.Generic;
using Webstore.Models;

namespace Webstore.DataContext.Contracts
{
    public interface ICartContext
    {
         Cart Get(string sessionId);
         void Delete(string sessionId);
    }
}