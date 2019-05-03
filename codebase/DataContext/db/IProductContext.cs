using System.Collections.Generic;
using Webstore.Models;

namespace Webstore.DataContext
{
    public interface IProductContext
    {
         Product Add(string name, double price);
         IEnumerable<Product> Get();
    }
}