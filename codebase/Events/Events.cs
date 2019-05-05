using System;

namespace Webstore.Events
{
    public class ProductCreated
    {
        public int ProductId { get; set; }
    }

    public class OrderPlaced
    {
        public long OrderId { get; set; }
        public string SessionId { get; set; }
        public string OrderNumber { get; set; }
    }

    public class OrderShipped
    {
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
    }

    public class OrderCancelled
    {
        public long OrderId { get; set; }
        public string OrderNumber { get; set; }
    }
}
