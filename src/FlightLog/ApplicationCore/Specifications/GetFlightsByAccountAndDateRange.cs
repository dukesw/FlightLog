using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByAccountAndDateRange : BaseSpecification<Flight>, ISpecification<Flight>
    {
        public GetFlightsByAccountAndDateRange(int accountId, DateTime startDate, DateTime endDate) 
            : base(x => x.AccountId == accountId && x.Date >= startDate && x.Date <= endDate)
        {
            Includes.Add(x => x.Model);
            Includes.Add(x => x.Battery);
            Includes.Add(x => x.Field);
            Includes.Add(x => x.Pilot);
        }
    }
}
