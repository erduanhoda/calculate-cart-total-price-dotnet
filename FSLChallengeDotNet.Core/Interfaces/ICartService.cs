using System.Threading.Tasks;
using FSLChallengeDotNet.Core.Dto.CartDTO;

namespace FSLChallengeDotNet.Core.Interfaces
{
    public interface ICartService
    {
        Task<GetTotalOutput> GetTotal(GetTotalInput input);
        Task Add(AddItemInput input);
        Task Remove(RemoveItemInput input);
    }
}
