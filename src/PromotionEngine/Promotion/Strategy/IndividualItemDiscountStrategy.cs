using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Checkout.Checkout;
using ShoppingCart.Checkout.Common;
using ShoppingCart.Checkout.Entities;
using ShoppingCart.Checkout.Promotion.Entities;

namespace ShoppingCart.Checkout.Promotion.Strategy
{
    class IndividualItemDiscountStrategy : ICartPriceCalculator
    {
        private Dictionary<string, IndividualItemDiscount> Promotions => GetPromotions();

        public double CalculateTotalPrice(Cart cart, IDictionary<string, Item> storeItems)
        {
            var total = 0.0;


            foreach (var item in cart.OrderItems)
            {
                var quantity = item.Value;
                var storeItem = storeItems.First(x => x.Key.Equals(item.Key, StringComparison.OrdinalIgnoreCase)).Value;

                if (Promotions.ContainsKey(item.Key))
                {
                    var offer = Promotions[item.Key];

                    if (offer.quantity < quantity)
                    {
                        total += (quantity % offer.quantity * storeItem.price) + (quantity / offer.quantity * offer.price);
                    }
                    else if (offer.quantity == quantity)
                    {
                        total += offer.price;
                    }
                    else
                    {
                        total += quantity * storeItem.price;
                    }
                }
                else
                {
                    total += quantity * storeItem.price;
                }
            }

            return total;
        }

        private Dictionary<string, IndividualItemDiscount> GetPromotions()
        {
            var promotions = JsonReader.LoadJson<List<IndividualItemDiscount>>("IndividualItemDiscount.json");

            return promotions.ToDictionary(p => p.name, p => p, StringComparer.OrdinalIgnoreCase);
        }
    }
}
