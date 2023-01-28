using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetMaintenanceLogByAccountAndModel : BaseSpecification<MaintenanceLog>, ISpecification<MaintenanceLog>
    {
        public GetMaintenanceLogByAccountAndModel(int accountId, int modelId) : base(m => m.AccountId == accountId && m.ModelId == modelId)
        {
            AddInclude(x => x.Type);
        }
    }
}