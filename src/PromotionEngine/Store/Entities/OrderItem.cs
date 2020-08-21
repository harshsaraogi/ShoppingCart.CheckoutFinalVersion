
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Checkout.Store.Entities
{
    public class OrderItem
    {
        public string ProductId { get; }
        public int Quantity { get; }

        public OrderItem(string product, int quantity)
        {
            ProductId = product;
            Quantity = quantity;
        }
    }
}
