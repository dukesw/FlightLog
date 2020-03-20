using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightByIdWithModel : BaseSpecification<Flight>
    {
 
        public GetFlightByIdWithModel(long id) : base(f => f.Id == id) 
        {
            AddInclude(f => f.Model);
        }
    }
}
