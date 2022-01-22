using Xunit;
using FSLChallengeDotNet.Core.Entities;
using System.Collections.Generic;

namespace FSLChallengeDotNet.Tests.Core
{
    public class CartTest
    {
        [Fact]
        public void Should_Not_Have_Nullable_CartItems()
        {
            Cart testableCart = new Cart();

            Assert.NotNull(testableCart.CartItems);
            Assert.Equal(typeof(HashSet<CartItem>), testableCart.CartItems.GetType());
        }

        [Fact]
        public void Should_Have_Zero_CartItems()
        {
            var testableCart = new Cart();

            Assert.Equal(0, testableCart.CartItems.Count);
        }

        [Fact]
        public void Should_Calculate_Total_Without_Discount_For_Single_Item_In_The_Cart()
        {
            var testableCart = new Cart();

            testableCart.CartItems.Add(InMemoryCartDataBuilder.BuildACartItemWithNonDiscountProductToTest("Vaso", 27, 1.2));

            Assert.NotEqual(36.4, testableCart.GetTotal());
            Assert.NotEqual(32.41, testableCart.GetTotal());
            Assert.NotEqual(32.29, testableCart.GetTotal());
            Assert.NotEqual(32.400001, testableCart.GetTotal());
            Assert.NotEqual(32.3999999, testableCart.GetTotal());
            Assert.Equal(32.4, testableCart.GetTotal());
        }

        [Fact]
        public void Should_Calculate_Total_Without_Discount_For_Multiple_Items_In_The_Cart()
        {
            var testableCart = new Cart();

            testableCart.CartItems.Add(InMemoryCartDataBuilder.BuildACartItemWithNonDiscountProductToTest("Vaso", 27, 1.2));
            testableCart.CartItems.Add(InMemoryCartDataBuilder.BuildACartItemWithNonDiscountProductToTest("Another Product", 250, 0.2));

            Assert.NotEqual(83.00, testableCart.GetTotal());
            Assert.NotEqual(82.41, testableCart.GetTotal());
            Assert.NotEqual(82.39, testableCart.GetTotal());
            Assert.Equal(82.40, testableCart.GetTotal());
            Assert.Equal(82.4, testableCart.GetTotal());
        }

        [Fact]
        public void Should_Calculate_Total_With_Discount_For_Single_Item_In_The_Cart()
        {
            var testableCart = new Cart();

            testableCart.CartItems.Add(InMemoryCartDataBuilder.BuildACartItemWithDiscountProductToTest("Big Mug", 17, 1, 2, 1.5));

            Assert.NotEqual(13.5, testableCart.GetTotal());
            Assert.NotEqual(13.01, testableCart.GetTotal());
            Assert.NotEqual(13.1, testableCart.GetTotal());
            Assert.NotEqual(13.0000001, testableCart.GetTotal());
            Assert.Equal(13.0, testableCart.GetTotal());
            Assert.Equal(13.00, testableCart.GetTotal());
            Assert.Equal(13, testableCart.GetTotal());
            Assert.Equal(13.000000000000, testableCart.GetTotal());
        }

        [Fact]
        public void Should_Calculate_Total_With_Discount_For_Multiple_Items_In_The_Cart()
        {
            var testableCart = new Cart();

            testableCart.CartItems.Add(InMemoryCartDataBuilder.BuildACartItemWithDiscountProductToTest("Big Mug", 17, 1, 2, 1.5));
            testableCart.CartItems.Add(InMemoryCartDataBuilder.BuildACartItemWithDiscountProductToTest("Napkins pack", 170, 0.45, 3, 0.9));
           
            Assert.NotEqual(63.9999, testableCart.GetTotal());
            Assert.NotEqual(64.31, testableCart.GetTotal());
            Assert.Equal(64.3, testableCart.GetTotal());
        }
    }
}
