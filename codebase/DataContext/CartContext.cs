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
                _carts.Add(cart);
            }
            return cart;
        }

        public void Delete(string sessionId)
        {
            var cart = _carts.SingleOrDefault(c => c.SessionId == sessionId);
            if (cart != null)
            {
                _carts.Remove(cart);
            }
        }
    }
}