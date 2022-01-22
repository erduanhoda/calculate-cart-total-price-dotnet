using System;
namespace FSLChallengeDotNet.Core.Exceptions
{
    public class ObjectException : Exception
    {
        public ObjectException(string message)
            :base(message) {}
    }
}
