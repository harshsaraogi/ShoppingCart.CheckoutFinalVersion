using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Checkout.Promotion.Entities
{
    internal class MultipleItemDiscount : DiscountItemBase
    {
        public string[] name { get; set; }
    }
}
