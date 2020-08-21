using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Checkout.Entities;

namespace ShoppingCart.Checkout.Checkout
{
    interface ICartPriceCalculator
    {
        double CalculateTotalPrice(Cart cart, IDictionary<string, Item> storeItems);
    }
}
