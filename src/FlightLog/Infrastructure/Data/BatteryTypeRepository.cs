using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class BatteryTypeRepository : EfRepository<BatteryType>, IBatteryTypeRepository
    {
        public BatteryTypeRepository(FlightLogContext context) : base(context)
        {
        }
    }
}
 