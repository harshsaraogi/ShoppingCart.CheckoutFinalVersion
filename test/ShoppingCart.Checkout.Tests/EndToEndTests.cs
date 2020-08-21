using System.Collections.Generic;
using ShoppingCart.Checkout.Checkout;
using ShoppingCart.Checkout.Common;
using ShoppingCart.Checkout.Entities;
using ShoppingCart.Checkout.Store.Entities;
using Xunit;

namespace ShoppingCart.Checkout.Tests
{
          public class EndToEndTests
          {
                    private readonly ICheckoutService _checkoutService;
                    public EndToEndTests()
                    {
                              _checkoutService = new CheckOutService();

                    }

                    [Fact]
                    public void ScenarioA()
                    {
                              var orderItems = new List<OrderItem>
            {
                new OrderItem("A", 1),
                new OrderItem("B", 1),
                new OrderItem("C", 1)
            };

                              var cart = new Cart();
                              cart.AddItems(orderItems);

                              var checkOutDetails = _checkoutService.CheckOutOrder(cart);

                              Assert.True(checkOutDetails.CartTotal == 100);
                    }

                    [Fact]
                    public void ScenarioB()
                    {
                              var orderItems = new List<OrderItem>
            {
                new OrderItem("A", 5),
                new OrderItem("B", 5),
                new OrderItem("C", 1)
            };

                              var cart = new Cart();
                              cart.AddItems(orderItems);

                              var checkOutDetails = _checkoutService.CheckOutOrder(cart);

                              Assert.True(checkOutDetails.CartTotal == 370);
                    }
          }
}
