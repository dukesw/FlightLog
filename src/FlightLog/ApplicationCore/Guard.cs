/// Copyright DukeSoftware 2018 ${itemname}

using DukeSoftware.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
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

        public static void AgainstBatteryNotFound(Battery battery, long batteryId, string variableName)
        {
            if (battery == null)
            {
                throw new BatteryNotFoundException(batteryId, variableName);
            }
        }

        public static void AgainstBatteryTypeNotFound(BatteryType batteryType, long batteryTypeId, string variableName)
        {
            if (batteryType == null)
            {
                throw new BatteryTypeNotFoundException(batteryTypeId, variableName);
            }
        }

        public static void AgainstAccountNumberMismatch(int accountIdOne, int accountIdTwo, string variableNameOne, string variableNameTwo)
        {
            if (accountIdOne != accountIdTwo)
            {
                throw new AccountConflictException(accountIdOne, accountIdTwo, variableNameOne, variableNameTwo);
            }
        }

        public static void AgainstAccountNumberMismatch(string accountIdOne, string accountIdTwo, string variableNameOne, string variableNameTwo)
        {
            if (accountIdOne != accountIdTwo)
            {
                throw new AccountConflictException(accountIdOne, accountIdTwo, variableNameOne, variableNameTwo);
            }
        }
    }
}