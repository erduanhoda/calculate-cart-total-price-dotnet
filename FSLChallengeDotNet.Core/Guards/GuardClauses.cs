using System;
using System.Collections.Generic;
using FSLChallengeDotNet.Core.Constants;
using FSLChallengeDotNet.Core.Exceptions;

namespace FSLChallengeDotNet.Core.Guards
{
    public static class GuardClauses
    {
        public static void IsNotEmptyGuid(Guid input)
        {
            if (input == Guid.Empty)
                throw new ArgumentNullException(GeneralExceptionMessages.EMPTY_GUID_EXCEPTION_MESSAGE);
        }

        public static void IsNotEmptyGuidArray(List<Guid> inputs)
        {
            foreach (var input in inputs)
                if (input == Guid.Empty)
                    throw new ArgumentNullException(GeneralExceptionMessages.EMPTY_GUID_EXCEPTION_MESSAGE);
        }

        public static void IsNotEmptyObject(object input)
        {
            if (input == null)
                throw new ObjectException(GeneralExceptionMessages.NULL_OBJECT_EXCEPTION_MESSAGE);
        }

        public static void IsNotEmptyObjectArray(List<object> inputs)
        {
            foreach (var input in inputs)
                if (input == null)
                    throw new ObjectException(GeneralExceptionMessages.NULL_OBJECT_EXCEPTION_MESSAGE);
        }
    }
}
