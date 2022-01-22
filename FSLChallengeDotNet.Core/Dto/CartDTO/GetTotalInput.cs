using System;
namespace FSLChallengeDotNet.Core.Dto.CartDTO
{
    public class GetTotalInput
    {
        public Guid CartId { get; private set; }

        public static GetTotalInput Instance(Guid cartId)
        {
            return new GetTotalInput { CartId = cartId };
        }
    }
}
