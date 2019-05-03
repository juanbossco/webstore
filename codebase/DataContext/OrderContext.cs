using Webstore.DataContext.Contracts;
using System.Collections.Generic;
using System.Linq;
using Webstore.Models;

namespace DataContext
{
    public class OrderContext : IOrderContext
    {
        private IList<Order> _orders;

        public OrderContext()
        {
            _orders = new List<Order>();
        }

        public Order Get(long orderId)
        {
            var order = _orders.SingleOrDefault(o => o.OrderId == orderId);
            return order;
        }

        public Order Get(string orderNumber)
        {
            var order = _orders.SingleOrDefault(o => o.OrderNumber == orderNumber);
            return order;
        }

        public Order Update(Order order)
        {
            var result = _orders.SingleOrDefault(o => o.OrderId == order.OrderId);
            return result;
        }

        public IEnumerable<Order> GetAll(string email)
        {
            var orders = _orders.Where(o => o.Customer.Email == email);
            return orders;
        }
    }
}