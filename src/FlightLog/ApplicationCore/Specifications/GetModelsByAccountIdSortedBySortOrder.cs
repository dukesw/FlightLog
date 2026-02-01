using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetModelsByAccountIdSortedBySortOrder : BaseSpecification<Model>, ISpecification<Model>
    {
        public GetModelsByAccountIdSortedBySortOrder(int accountId) : base(x => x.AccountId == accountId)
        {
            Includes.Add(x => x.Status);
            ApplyOrderBy(x => x.SortOrder);
        }
    }
}
