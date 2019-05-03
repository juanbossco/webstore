using Product.Model;
using System.Collections.Generic;

namespace Product.db.Contracts
{
    public interface IDbProduct
    {
         ProductModel Add(string name, double price);
         IEnumerable<ProductModel> Get();
    }
}