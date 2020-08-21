using System;

namespace ShoppingCart.Checkout.Checkout.Entities
{
    public class CheckOutDetails
    {
        public Guid CartId { get; }
        public double CartTotal { get; }

        public CheckOutDetails(Guid cartId, double cartTotal)
        {
            CartId = cartId;
            CartTotal = cartTotal;
        }
    }
}
