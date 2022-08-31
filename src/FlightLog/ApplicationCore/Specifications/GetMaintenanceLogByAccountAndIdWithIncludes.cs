using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetMaintenanceLogByAccountAndIdWithIncludes : BaseSpecification<MaintenanceLog>, ISpecification<MaintenanceLog>
    {
        public GetMaintenanceLogByAccountAndIdWithIncludes(int accountId, int id) : base(m => m.AccountId == accountId && m.Id == id)
        {
            AddInclude(m => m.Model);
            AddInclude(x => x.Type);
        }
    }
}