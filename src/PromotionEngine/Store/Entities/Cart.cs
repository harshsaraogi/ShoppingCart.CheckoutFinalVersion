using System;
using System.Collections.Generic;

namespace ShoppingCart.Checkout.Entities
{
          public class Cart
          {
                    public Dictionary<string, int> OrderItems { get; private set; }

                    public Guid CartId { get; }

                    public Cart()
                    {
                              OrderItems = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
                              CartId = Guid.NewGuid();
                    }
          }
}
