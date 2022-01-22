using System;
namespace FSLChallengeDotNet.Core.Dto.CartDTO
{
    public class AddItemInput
    {
        public Guid CartId { get; private set; }
        public Guid ItemId { get; private set; }

        public static AddItemInput Instance(Guid cartId, Guid itemId)
        {
            return new AddItemInput { CartId = cartId, ItemId = itemId };
        }
    }
}
