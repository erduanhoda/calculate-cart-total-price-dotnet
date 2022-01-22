using System;

namespace FSLChallengeDotNet.Core.Entities
{
    public class ItemDiscountRule : BaseEntity
    {
        public double Quantity { get; set; } 
        public double Price { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}
