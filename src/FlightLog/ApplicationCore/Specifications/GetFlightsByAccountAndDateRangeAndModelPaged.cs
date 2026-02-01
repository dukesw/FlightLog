using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByAccountAndDateRangeAndModelPaged : GetFlightsByAccountAndDateRangeAndModel
    {
        public GetFlightsByAccountAndDateRangeAndModelPaged(int accountId, DateTime startDate, DateTime endDate, int modelId, int skip, int take)
            : base(accountId, startDate, endDate, modelId)
        {
            ApplyPaging(skip, take);
        }
    }
}
