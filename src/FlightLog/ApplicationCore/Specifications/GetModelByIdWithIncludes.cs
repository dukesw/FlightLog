using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetModelByIdWithIncludes : BaseSpecification<Model>, ISpecification<Model>
    {
        public GetModelByIdWithIncludes(int id) : base(m => m.Id == id)
        {
            AddInclude(m => m.Flights);
        }
    }
}
