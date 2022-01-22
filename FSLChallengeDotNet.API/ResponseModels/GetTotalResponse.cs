namespace FSLChallengeDotNet.API.ResponseModels
{
    public class GetTotalResponse
    {
        public double Total { get; private set; }

        public static GetTotalResponse Instance(double total)
        {
            return new GetTotalResponse { Total = total };
        }
    }
}
