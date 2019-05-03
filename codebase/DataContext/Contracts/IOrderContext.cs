using System.Collections.Generic;
using Webstore.Models;

namespace Webstore.DataContext.Contracts
{
    public interface IOrderContext
    {
         Order Get(long orderId);
         Order Get(string orderNumber);
         IEnumerable<Order> GetAll(string email);
         Order Update(Order order);
    }
}