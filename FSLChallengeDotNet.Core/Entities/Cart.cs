using System;
using System.Collections.Generic;

namespace FSLChallengeDotNet.Core.Entities
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public Guid UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public double GetTotal()
        {
            if (CartItems.Count == 0) return 0;

            double total = 0;

            foreach (var cartItem in CartItems)
            {
                var discountRule = cartItem.Item.DiscountRule;

                if (discountRule != null)
                {
                    total += CalculateTotal(cartItem);
                    continue;
                }

                total += CalculateTotalWithoutDiscout(cartItem);
            }

            return Math.Round(total, 2);
        }

        private static double CalculateTotalWithoutDiscout(CartItem cartItem)
        {
            return cartItem.Quantity * cartItem.Item.UnitPrice;
        }

        private static double CalculateTotal(CartItem cartItem)
        {
            var quantity = cartItem.Quantity;
            var unitPrice = cartItem.Item.UnitPrice;
            var discountRule = cartItem.Item.DiscountRule;

            return ((Math.Floor(quantity / discountRule.Quantity) * discountRule.Price)) +
                 ((quantity % discountRule.Quantity) * unitPrice);
        }
    }
}
