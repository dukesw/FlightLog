using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetBatteryByIdWithIncludes : BaseSpecification<Battery>, ISpecification<Battery>
    {
        public GetBatteryByIdWithIncludes(long id) : base(x => x.Id == id)
        {
            AddInclude(x => x.BatteryType);
        }

    }
}
