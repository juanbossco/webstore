using System.Collections.Generic;
using System.Linq;
using System;

namespace Webstore.Models
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
        public Product Product { get; protected set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private IList<CartItem> _products;

        public Cart(string sessionId)
        {
            _products = new List<CartItem>();
            this.SessionId = sessionId;
        }

        protected int Id { get; }
        public string SessionId { get; protected set; }

        public IEnumerable<CartItem> Products => _products;

        public IEnumerable<CartItem> Update(CartItem product)
        {
            var cartProduct = _products.SingleOrDefault(p => p.Product.ProductId == product.Product.ProductId);

            if (cartProduct == null)
            {
                _products.Add(product);
                return _products;
            }

            if (product.Quantity == 0)
            {
                _products.Remove(cartProduct);
                return _products;
            }

            cartProduct.Quantity = product.Quantity;

            return _products;
        }
    }
}
