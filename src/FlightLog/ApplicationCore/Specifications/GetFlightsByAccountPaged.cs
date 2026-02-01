using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetFlightsByAccountPaged : GetFlightsByAccount
    {
        public GetFlightsByAccountPaged(int accountId, int skip, int take) : base(accountId)
        {
            ApplyPaging(skip, take);
        }
    }
}
