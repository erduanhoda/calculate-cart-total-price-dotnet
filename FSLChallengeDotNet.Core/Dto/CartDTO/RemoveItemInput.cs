using System;
namespace FSLChallengeDotNet.Core.Dto.CartDTO
{
    public class RemoveItemInput
    {
        public Guid CartId { get; private set; }
        public Guid ItemId { get; private set; }

        public static RemoveItemInput Instance(Guid cartId, Guid itemId)
        {
            return new RemoveItemInput { CartId = cartId, ItemId = itemId };
        }
    }
}
