using System.Collections.Generic;
using System.Linq;
using System;

namespace Webstore.Models
{
    public class Order
    {
        public Order(Customer customer, Cart cart)
        {
            this.Customer = customer;
            this.Cart = cart;
            this.OrderNumber = (new Guid()).ToString();
            this.PlacedDate = DateTime.UtcNow;
        }

        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public Cart Cart {get;set;}
        public DateTime PlacedDate { get; set; }

    }
}