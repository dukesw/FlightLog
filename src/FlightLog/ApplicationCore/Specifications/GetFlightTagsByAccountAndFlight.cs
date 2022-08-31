using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightTagsByAccountAndFlight : BaseSpecification<FlightTag>
    {
        public GetFlightTagsByAccountAndFlight(int accountId, int flightId) : base(x => x.Id == accountId && x.Id == flightId)
        {
            //Includes.Add(f => f.Field);
            //Includes.Add(f => f.Model);
            //Includes.Add(f => f.Battery);
            //Includes.Add(f => f.MediaLinks);
            //Includes.Add(f => f.Pilot);
            //ApplyOrderBy(x => x.Date);
        }
    }
}
