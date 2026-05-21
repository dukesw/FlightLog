using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetPilotsByIsActiveAndAccount : BaseSpecification<Pilot>
    {
        public GetPilotsByIsActiveAndAccount(int accountId) : base(x => x.AccountId == accountId && x.isActive)
        { 
          
        }
    }
}
