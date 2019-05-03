using System.Collections.Generic;
using Webstore.Models;
using Webstore.DataContext.Contracts;

namespace Webstore.DataContext
{

    public class ProductContext : IProductContext
    {
        private IList<Product> _products;
        public ProductContext()
        {
            _products = new List<Product>();
        }

        public Product Add(string name, double price)
        {
            var id = _products.Count + 1;
            var product = new Product(id, name, price);
            _products.Add(product);
            return product;
        }

        public IEnumerable<Product> Get()
        {
            return _products;
        }
    }
}