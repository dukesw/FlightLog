using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByDateRange : BaseSpecification<Flight>, ISpecification<Flight>
    {
        public GetFlightsByDateRange(DateTime startDate, DateTime endDate) : base(x => x.Date >= startDate && x.Date <= endDate)
        {
            Includes.Add(x => x.Model);
            Includes.Add(x => x.Battery);
            Includes.Add(x => x.Field);
            Includes.Add(x => x.Pilot);
        }
    }
}
