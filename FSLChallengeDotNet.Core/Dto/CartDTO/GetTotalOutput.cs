namespace FSLChallengeDotNet.Core.Dto.CartDTO
{
    public class GetTotalOutput
    {
        public double Total { get; private set; }

        public static GetTotalOutput Instance(double total)
        {
            return new GetTotalOutput { Total = total }; 
        }
    }
}
