using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetModelsByAccountId :  BaseSpecification<Model>, ISpecification<Model>
    {
        public GetModelsByAccountId(int accountId) : base(x => x.AccountId == accountId)
        {
            ApplyOrderBy(x => x.SortOrder);
        }
    }
}
