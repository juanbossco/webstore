using System;
using Xunit;
using Webstore.DataContext.Contracts;
using Webstore.DataContext;

namespace Test.DataContext
{
    public class CartContextTest
    {
        private readonly ICartContext _cartCtx;
        public CartContextTest()
        {
            _cartCtx = new CartContext();
        }

        [Fact]
        public void CanAddCart()
        {
            //Given
            var sessionId = new Guid().ToString();
            //When
            var cart = _cartCtx.Get(sessionId);
            //Then
            Assert.True(cart != null, "Cart is null");
            Assert.True(cart.SessionId == sessionId, "Session Id does not match");
        }
    }
}