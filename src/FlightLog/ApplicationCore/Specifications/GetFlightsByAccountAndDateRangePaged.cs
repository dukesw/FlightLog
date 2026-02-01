using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByAccountAndDateRangePaged : GetFlightsByAccountAndDateRange
    {
        public GetFlightsByAccountAndDateRangePaged(int accountId, DateTime startDate, DateTime endDate, int skip, int take) 
            : base(accountId, startDate, endDate)
        {
            ApplyPaging(skip, take);
        }
    }
}
