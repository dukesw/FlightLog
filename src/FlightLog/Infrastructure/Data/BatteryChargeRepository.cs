using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class BatteryChargeRepository : EfRepository<BatteryCharge>, IBatteryChargeRepository
    {
        public BatteryChargeRepository(FlightLogContext context) : base(context)
        {
        }
    }
}
