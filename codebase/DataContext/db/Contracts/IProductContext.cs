using System.Collections.Generic;
using Webstore.Models;

namespace Webstore.DataContext.Contracts
{
    public interface IProductContext
    {
         Product Add(string name, double price);
         IEnumerable<Product> Get();
    }
}