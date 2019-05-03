using System.Collections.Generic;
using System.Linq;
using System;

namespace Webstore.Models
{
    public class Order
    {
        public Order(Customer customer, IEnumerable<Product> products)
        {
            this.Customer = customer;
            this.Products = products;
            this.OrderNumber = (new Guid()).ToString();
            this.PlacedDate = DateTime.UtcNow;
        }

        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public DateTime PlacedDate { get; set; }

    }
}