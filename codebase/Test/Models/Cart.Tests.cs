using System;
using Xunit;
using System.Linq;
using Webstore.Models;
using Webstore.DataContext;
using Webstore.DataContext.Contracts;

namespace Models
{
    public class CartTest
    {
        private readonly ICartContext _cartContext;
        private readonly IProductContext _productCtx;

        public CartTest()
        {
            this._cartContext = new CartContext();
            this._productCtx = new ProductContext();
        }

        [Fact]
        public void CanUpdateCart()
        {
            //Expected
            var expectedQuantity = 3;
            //Given
            var product = _productCtx.Add("cup", 10.5);
            var sessionId = new Guid().ToString();
            //When
            var cart = _cartContext.Get(sessionId);
            var cartProduct = new CartProduct(product, expectedQuantity);
            cart.Update(cartProduct);
            //Then
            var newProduct = cart.Products.SingleOrDefault(p => p.Product.ProductId == product.ProductId);
            Assert.True(newProduct != null, "Product added to Cart is null");
            Assert.True(newProduct.Quantity == expectedQuantity, "Quantity does not match");
        }
    }
}
