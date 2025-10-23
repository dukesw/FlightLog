using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightCountByAccountAndDateRange : BaseSpecification<Flight>, ISpecification<Flight>
    {
        public GetFlightCountByAccountAndDateRange(int accountId, DateTime startDate, DateTime endDate) 
            : base(x => x.AccountId == accountId && x.Date >= startDate && x.Date <= endDate)
        {
           
        }
    }
}
