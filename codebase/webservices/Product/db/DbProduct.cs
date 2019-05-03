using System.Collections.Generic;
using Product.Model;
using Product.db.Contracts;

namespace Product.db
{

    public class DbProduct : IDbProduct
    {
        private IList<ProductModel> _products;
        public DbProduct()
        {
            _products = new List<ProductModel>();
        }

        public ProductModel Add(string name, double price)
        {
            var id = _products.Count + 1;
            var product = new ProductModel(id, name, price);
            _products.Add(product);
            return product;
        }

        public IEnumerable<ProductModel> Get()
        {
            return _products;
        }
    }
}