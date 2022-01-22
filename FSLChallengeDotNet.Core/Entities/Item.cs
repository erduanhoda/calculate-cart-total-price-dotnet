using System.Collections.Generic;

namespace FSLChallengeDotNet.Core.Entities
{
    public class Item : BaseEntity
    {
        public string SKU { get; set; }
        public double UnitPrice { get; set; }

        public virtual ItemDiscountRule DiscountRule { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
