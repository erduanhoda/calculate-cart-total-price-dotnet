using System;
namespace FSLChallengeDotNet.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public double Quantity { get; set; }

        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
