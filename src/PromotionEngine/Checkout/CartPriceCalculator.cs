using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Checkout.Entities;
using ShoppingCart.Checkout.Promotion.Strategy;

namespace ShoppingCart.Checkout.Checkout
{
    internal class CartPriceCalculator : ICartPriceCalculator
    {
        public double CalculateTotalPrice(Cart cart, IDictionary<string, Item> storeItems)
        {
            var storePromotions = GetStorePromotions();

            var calculatedCartPrices = new List<double>();

            foreach (var item in storePromotions)
            {
                var result = item.CalculateTotalPrice(cart, storeItems);
                calculatedCartPrices.Add(result);
            }

            return calculatedCartPrices.Min();
        }

        private IList<ICartPriceCalculator> GetStorePromotions()
        {
            return new List<ICartPriceCalculator> { new IndividualItemDiscountStrategy(), new MultipleItemDiscountStrategy() };
        }
    }
}
