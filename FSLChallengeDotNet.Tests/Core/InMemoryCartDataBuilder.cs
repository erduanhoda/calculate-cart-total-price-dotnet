using FSLChallengeDotNet.Core.Entities;

namespace FSLChallengeDotNet.Tests.Core
{
    public class InMemoryCartDataBuilder
    {
        public static CartItem BuildACartItemWithNonDiscountProductToTest(string sku, double quantity, double unitPrice)
        {
            return new CartItem
            {
                Quantity = quantity,
                Item = new Item
                {
                    SKU = sku,
                    UnitPrice = unitPrice
                }
            };
        }

        public static CartItem BuildACartItemWithDiscountProductToTest(string sku, double quantity, double unitPrice, double discountQuantity, double priceQuantity)
        {
            return new CartItem
            {
                Quantity = quantity,
                Item = new Item
                {
                    SKU = sku,
                    UnitPrice = unitPrice,
                    DiscountRule = new ItemDiscountRule
                    {
                        Quantity = discountQuantity,
                        Price = priceQuantity
                    }
                }
            };
        }
    }
}
