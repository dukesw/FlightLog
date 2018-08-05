using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Exceptions
{
    public class BatteryTypeNotFoundException : Exception
    {
        public BatteryTypeNotFoundException(long batteryTypeId, string variableName) : base($"Battery Type with Id = {batteryTypeId} not found, variable = {variableName}")
        {
        }
    }
}
