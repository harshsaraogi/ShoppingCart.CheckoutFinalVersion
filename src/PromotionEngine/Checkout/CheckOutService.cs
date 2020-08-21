using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ShoppingCart.Checkout.Checkout.Entities;
using ShoppingCart.Checkout.Common;
using ShoppingCart.Checkout.Entities;

[assembly: InternalsVisibleTo("ShoppingCart.Checkout.Tests")]

namespace ShoppingCart.Checkout.Checkout
{
    internal class CheckOutService : ICheckoutService
    {
        private Dictionary<string, Item> StoreItems => GetStoreItems();

        public CheckOutDetails CheckOutOrder(Cart cart)
        {
            var cartTotal = new CartPriceCalculator().CalculateTotalPrice(cart, StoreItems);

            return new CheckOutDetails(cart.CartId, cartTotal);
        }

        private Dictionary<string, Item> GetStoreItems()
        {
            var promotions = JsonReader.LoadJson<List<Item>>("ItemList.json");

            return promotions.ToDictionary(p => p.productId, p => p, StringComparer.OrdinalIgnoreCase);
        }
    }
}
