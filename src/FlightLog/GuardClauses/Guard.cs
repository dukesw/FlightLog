using DukeSoftware.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;
using DukeSoftware.Exceptions;

namespace DukeSoftware.GuardClauses
{
    public static class Guard
    {
        public static void AgainstNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void AgainstEmptyString(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new EmptyStringException(argumentName);
            }
        }
    }
}
