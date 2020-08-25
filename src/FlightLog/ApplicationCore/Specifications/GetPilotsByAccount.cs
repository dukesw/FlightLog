using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetPilotsByAccount : BaseSpecification<Pilot>
    {
        public GetPilotsByAccount(int accountId) : base(x => x.AccountId == accountId)
        { 
          
        }
    }
}
