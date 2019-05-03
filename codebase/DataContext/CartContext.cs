using Webstore.DataContext.Contracts;
using Webstore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Webstore.DataContext
{
    public class CartContext : ICartContext
    {
        private readonly IList<Cart> _carts;
        public CartContext()
        {
            _carts = new List<Cart>();
        }

        public Cart Get(string sessionId)
        {
            var cart = _carts.SingleOrDefault(c => c.SessionId == sessionId);
            if (cart == null)
            {
                cart = new Cart(sessionId);
            }
            return cart;
        }
    }
}