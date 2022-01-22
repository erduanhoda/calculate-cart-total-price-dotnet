using System;
using System.Collections.Generic;
using System.Linq;
using FSLChallengeDotNet.Core.Entities;
using FSLChallengeDotNet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FSLChallengeDotNet.API
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!context.Carts.Any()) context.Carts.AddRange(SeedCartData());
                if (!context.Items.Any()) context.Items.AddRange(SeedItemData());
                if (!context.ItemDiscountRule.Any()) context.ItemDiscountRule.AddRange(SeedItemDiscoutRuleData());

                context.SaveChanges();
            }
        }

        private static List<Cart> SeedCartData()
        {
            return new List<Cart>
            {
                new Cart { Id = new Guid("4e5fc42c-4a3a-46bf-bdc6-93e67e1e9abb"), UserId = new Guid("aa57924c-a78a-482b-a184-40917498e541") },
                new Cart { Id = new Guid("9370d3af-7c05-46a8-940e-250f21cbbb76"), UserId = new Guid("2400c2c4-cd1e-462a-908e-6359cb62aa04") },
                new Cart { Id = new Guid("ee1605d8-9bcd-4054-811e-27d5985bee64"), UserId = new Guid("2400c2c4-cd1e-462a-908e-6359cb62aa04") },
            };
        }

        private static List<Item> SeedItemData()
        {
            return new List<Item>
            {
                new Item { Id = new Guid("e5715f5d-5c72-4564-9bbd-31bdedb93bed"), SKU = "Vase", UnitPrice = 1.2 },
                new Item { Id = new Guid("af3987bb-8a3b-4e53-b61b-858883655c8e"), SKU = "Big mug", UnitPrice = 1 },
                new Item { Id = new Guid("40ebcec1-9268-4e34-8d10-a47bd9d10fa4"), SKU = "Napkins pack", UnitPrice = 0.45  },
            };
        }

        private static List<ItemDiscountRule> SeedItemDiscoutRuleData()
        {
            return new List<ItemDiscountRule>
            {
                new ItemDiscountRule { Id = new Guid("e0b358c4-b225-42b0-a272-1846b94ee4db"), Quantity = 2, Price = 1.5, ItemId = new Guid("af3987bb-8a3b-4e53-b61b-858883655c8e") },
                new ItemDiscountRule { Id = new Guid("c0a7d3c6-c259-4987-b9dd-f480a7f1a342"), Quantity = 3, Price = 0.9, ItemId = new Guid("40ebcec1-9268-4e34-8d10-a47bd9d10fa4") },
            };
        }
    }
}
