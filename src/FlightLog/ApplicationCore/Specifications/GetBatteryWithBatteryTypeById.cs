using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetBatteryWithBatteryTypeById : BaseSpecification<Battery>, ISpecification<Battery>
    {
        public GetBatteryWithBatteryTypeById(long id) : base(x => x.Id == id)
        {
            AddInclude(x => x.BatteryType);
        }

    }
}
