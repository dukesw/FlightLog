using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByModel : BaseSpecification<Flight>, ISpecification<Flight>
    {
        public GetFlightsByModel(int modelId) : base(x => x.ModelId == modelId)
        {
            Includes.Add(x => x.Model);
            Includes.Add(x => x.Battery);
            Includes.Add(x => x.Field);
        }
    }
}
