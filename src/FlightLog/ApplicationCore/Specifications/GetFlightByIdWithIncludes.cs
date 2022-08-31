using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightByIdWithIncludes : BaseSpecification<Flight>
    {
 
        public GetFlightByIdWithIncludes(long id) : base(f => f.Id == id) 
        {
            Includes.Add(f => f.Field);
            Includes.Add(f => f.Model);
            Includes.Add(f => f.Battery);
            Includes.Add(f => f.MediaLinks);
            Includes.Add(f => f.Pilot);
            Includes.Add(f => f.Tags);
        }
    }
}
