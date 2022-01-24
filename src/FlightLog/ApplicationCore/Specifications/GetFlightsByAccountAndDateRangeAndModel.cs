using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByAccountAndDateRangeAndModel : BaseSpecification<Flight>, ISpecification<Flight>
    {
        public GetFlightsByAccountAndDateRangeAndModel(int accountId, DateTime startDate, DateTime endDate, int modelId)
            : base(x => x.AccountId == accountId && x.Date >= startDate && x.Date <= endDate && x.ModelId == modelId)
        {
            Includes.Add(x => x.Model);
            Includes.Add(x => x.Battery);
            Includes.Add(x => x.Field);
            Includes.Add(x => x.Pilot);
            ApplyOrderBy(x => x.Date);
        }
    }
}
