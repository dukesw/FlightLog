using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetMaintenanceLogByAccountAndModelPaged : GetMaintenanceLogByAccountAndModel
    {
        public GetMaintenanceLogByAccountAndModelPaged(int accountId, int modelId, int skip, int take) : base(accountId, modelId)
        {
            ApplyPaging(skip, take);
        }
    }
}