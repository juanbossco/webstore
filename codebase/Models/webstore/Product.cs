using System.Collections.Generic;
using System.Linq;

namespace Webstore.Models
{
    public class Property
    {
        public Property(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
        protected int PropertyId { get; set; }
        public string Name { get; set;}
        public string Type { get; set;}
    }

    public class ProductProperty
    {
        public ProductProperty(Property property, string value)
        {
            Property = property;
            Value = value;
        }

        protected int ProductPropertyId { get; set; }
        public Property Property { get; }
        public string Value { get; }
    }

    public class Product
    {
        private IList<ProductProperty> _properties;

        public Product(long productId, string name, double price)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this._properties = new List<ProductProperty>();
        }

        public long ProductId { get; }
        public string Name { get; }
        public double Price { get; }
        public IEnumerable<ProductProperty> Properties
        {
            get
            {
                return _properties;
            }
        }

        public void AddProperty(Property property, string value)
        {
            if (!_properties.Any(p => p.Property.Name == property.Name))
            {
                var productProperty = new ProductProperty(property, value);
                _properties.Add(productProperty);
            }
        }
    }
}