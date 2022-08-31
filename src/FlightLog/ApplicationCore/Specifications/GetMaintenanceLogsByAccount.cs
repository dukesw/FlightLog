using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetMaintenanceLogsByAccount : BaseSpecification<MaintenanceLog>, ISpecification<MaintenanceLog>
    {
        public GetMaintenanceLogsByAccount(int accountId) : base(m => m.AccountId == accountId)
        {
            AddInclude(x => x.Model);
            AddInclude(x => x.Type);
            AddInclude(x => x.Model);
        }
    }
}