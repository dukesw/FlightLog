using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Exceptions
{
    public class BatteryNotFoundException : Exception
    {
        public BatteryNotFoundException(long batteryId, string variableName) : base($"Battery with Id = {batteryId} not found, variable = {variableName}")
        {
        }
    }   
}
