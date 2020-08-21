using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Checkout.Entities;
using ShoppingCart.Checkout.Store.Entities;

namespace ShoppingCart.Checkout.Common
{
    static public  class CartExtensions
    {
        static private List<Item> StoreItems => JsonReader.LoadJson<List<Item>>("ItemList.json");

        static public void AddItem(this Cart cart, OrderItem item)
        {
            if(!StoreItems.Any(i => i.productId.Equals(item.ProductId)))
            {
                throw new ArgumentException("Invalid product Id", nameof(item.ProductId));
            }

            if (cart.OrderItems.ContainsKey(item.ProductId))
            {
                cart.OrderItems[item.ProductId] += item.Quantity;
            }
            else
            {
                cart.OrderItems.Add(item.ProductId, item.Quantity);
            }
        }

        static public void AddItems(this Cart cart, IEnumerable<OrderItem> items)
        {
            foreach (var item in items)
            {
                AddItem(cart, item);
            }
        }
    }
}
