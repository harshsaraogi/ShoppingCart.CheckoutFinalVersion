using System;
using ShoppingCart.Checkout.Checkout.Entities;
using ShoppingCart.Checkout.Entities;

namespace ShoppingCart.Checkout.Checkout
{
    public interface ICheckoutService
    {
        CheckOutDetails CheckOutOrder(Cart cart);
    }
}
