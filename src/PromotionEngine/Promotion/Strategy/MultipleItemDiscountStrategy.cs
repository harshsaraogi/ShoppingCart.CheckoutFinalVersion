using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Checkout.Checkout;
using ShoppingCart.Checkout.Common;
using ShoppingCart.Checkout.Entities;

namespace ShoppingCart.Checkout.Promotion.Strategy
{
    class MultipleItemDiscountStrategy : ICartPriceCalculator
    {
        private List<Item> Promotions => JsonReader.LoadJson<List<Item>>("MultipleItemDiscount.json");

        public double CalculateTotalPrice(Cart cart, IDictionary<string, Item> storeItems)
        {
            return double.MaxValue;
        }
    }
}
