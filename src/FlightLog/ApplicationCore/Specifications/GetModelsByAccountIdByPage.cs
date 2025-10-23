using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetModelsByAccountIdByPage : GetModelsByAccountId
    {
        public GetModelsByAccountIdByPage(int accountId, int skip, int take) : base(accountId)
        {
            ApplyPaging(skip, take);
        }

        public GetModelsByAccountIdByPage(int accountId, int skip, int take, string sortBy = "", bool descending = false) : base(accountId)
        {
            Expression<Func<Model, object>> columnSort =
                sortBy == "Name" ? x => x.Name :
                sortBy == "Manufacturer" ? x => x.Manufacturer :
                sortBy == "Status" ? x => x.Status :
                sortBy == "MaidenedOn" ? x => x.MaidenedOn :
                sortBy == "PurchasedOn" ? x => x.PurchasedOn :
                sortBy == "DisposedOn" ? x => x.DisposedOn :
                sortBy == "LoggedFlights" ? x => x.LoggedFlights :
                sortBy == "TotalFlights" ? x => x.TotalFlights :
                x => x.SortOrder; // Default sort by name

            if (descending)
            {
                ApplyOrderByDescending(columnSort); // Default sort by name
            }
            else
            {
                ApplyOrderBy(columnSort);
            }
            ApplyPaging(skip, take);
        }

    }
}
