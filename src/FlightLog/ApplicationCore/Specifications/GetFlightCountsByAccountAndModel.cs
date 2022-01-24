using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightCountsByAccountAndModel : BaseSpecification<Flight>
    {
        public GetFlightCountsByAccountAndModel(int accountId, int modelId) : base(x => x.AccountId == accountId && x.ModelId == modelId)
        {

        }
    }
}
