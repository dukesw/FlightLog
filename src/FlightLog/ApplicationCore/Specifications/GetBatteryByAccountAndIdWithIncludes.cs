using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetBatteryByAccountAndIdWithIncludes : BaseSpecification<Battery>, ISpecification<Battery>
    {
        public GetBatteryByAccountAndIdWithIncludes(int accountId, long id) : base(x => x.Id == id && x.AccountId == accountId)
        {
            AddInclude(x => x.BatteryType);
        }

    }
}
