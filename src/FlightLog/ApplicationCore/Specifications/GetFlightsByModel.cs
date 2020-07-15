using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByModel : BaseSpecification<Flight>
    {
        public GetFlightsByModel(int modelId) : base(x => x.ModelId == modelId)
        {
            Includes.Add(f => f.Field);
            Includes.Add(f => f.Model);
            Includes.Add(f => f.Battery);
            Includes.Add(f => f.MediaLinks);
            Includes.Add(f => f.Pilot);
        }
    }
}
