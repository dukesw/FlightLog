using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Exceptions
{
    public class AccountConflictException : Exception
    {
        public AccountConflictException(int accountIdOne, int accountIdTwo, string variableOneName, string variableTwoName) :
            base($"There was an account conflict in the variables '{variableOneName}' = {accountIdOne} and '{variableTwoName}' = {accountIdTwo}")
        { }

        public AccountConflictException(string accountIdOne, string accountIdTwo, string variableOneName, string variableTwoName) :
           base($"There was an account conflict in the variables '{variableOneName}' = {accountIdOne} and '{variableTwoName}' = {accountIdTwo}")
        { }
    }
}
