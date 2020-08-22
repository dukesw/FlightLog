using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByAccount : BaseSpecification<Flight>
    {
        public GetFlightsByAccount(int accountId) : base(x => x.AccountId == accountId)
        {
            Includes.Add(f => f.Field);
            Includes.Add(f => f.Model);
            Includes.Add(f => f.Battery);
            Includes.Add(f => f.MediaLinks);
            Includes.Add(f => f.Pilot);
        }
    }
}
