using System;
using Xunit;
using Webstore.DataContext.Contracts;
using Webstore.DataContext;

namespace Test.DataContext
{
    public class ProductContextTest
    {
        private readonly IProductContext _productCtx;
        public ProductContextTest()
        {
            this._productCtx = new ProductContext();
        }

        [Fact]
        public void CanAddProduct()
        {
            var expectedName = "cup";
            var expectedPrice = 10.5;

            var result = _productCtx.Add("cup", 10.5);
            Assert.NotNull(result);
            Assert.True(result.Name == expectedName, "Name doest not match");
            Assert.True(result.Price == expectedPrice, "Price doest not match");
            Assert.True(result.ProductId > 0, "Product Id was not set");
        }
    }
}
