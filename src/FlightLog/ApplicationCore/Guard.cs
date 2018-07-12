// Copyright DukeSoftware 2018 ${itemname}

using DukeSoftware.Exceptions;
using System;

namespace DukeSoftware.GuardClauses
{
    public static class Guard
    {
        public static void AgainstEmptyString(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new EmptyStringException(argumentName);
            }
        }

        public static void AgainstNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}