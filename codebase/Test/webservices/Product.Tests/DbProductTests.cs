using System;
using Xunit;
using Webstore.DataContext;

namespace Product.Tests
{
    public class DbProductTests
    {
        private readonly IProductContext _dbProduct;
        public DbProductTests()
        {
            this._dbProduct = new ProductContext();
        }

        [Fact]
        public void CanAddProduct()
        {
            var expectedName = "cup";
            var expectedPrice = 10.5;

            var result = _dbProduct.Add("cup", 10.5);
            Assert.NotNull(result);
            Assert.True(result.Name == expectedName, "Name doest not match");
            Assert.True(result.Price == expectedPrice, "Price doest not match");
            Assert.True(result.ProductId > 0, "Product Id was not set");
        }
    }
}
