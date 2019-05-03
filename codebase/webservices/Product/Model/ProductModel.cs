using System.Collections.Generic;

namespace Product.Model
{
    public class Property
    {
        public Property(){
            
        }
        protected int PropertyId { get; set; }
        public string Name { get; }
        public string Type { get; }
    }

    public class ProductProperty
    {
        public ProductProperty(){

        }

        protected int ProductPropertyId { get; set; }
        public Property Property { get; }
        public string Value { get; }
    }

    public class ProductModel
    {
        public ProductModel(long productId, string name, double price)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.Properties = new List<ProductProperty>();
        }

        public long ProductId { get; }
        public string Name { get; }
        public double Price { get; }
        protected IList<ProductProperty> Properties { get; set; }
    }
}