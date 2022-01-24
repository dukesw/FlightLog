using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetModelByAccountAndIdWithIncludes : BaseSpecification<Model>, ISpecification<Model>
    {
        public GetModelByAccountAndIdWithIncludes(int accountId, int id) : base(m => m.AccountId == accountId && m.Id == id)
        {
            AddInclude(m => m.Flights);
            AddInclude(x => x.Status);
        }
    }
}
