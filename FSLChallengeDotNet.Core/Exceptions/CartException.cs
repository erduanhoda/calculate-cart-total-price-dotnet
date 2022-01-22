using System;
namespace FSLChallengeDotNet.Core.Exceptions
{
    public class CartException : Exception
    {
        public CartException(string message)
            :base(message) {}
    }
}
