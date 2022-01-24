using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetModelsByAccountIdAndIsActive :  BaseSpecification<Model>, ISpecification<Model>
    {
        public GetModelsByAccountIdAndIsActive(int accountId, bool isActive) : base(x => x.AccountId == accountId && x.Status.IsActive == isActive)
        {
            Includes.Add(x => x.Status);
            ApplyOrderBy(x => x.SortOrder);
        }
    }
}
