using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    public class GetAccountById : BaseSpecification<Account>, ISpecification<Account>
    {
        public GetAccountById(int accountId) : base(x => x.Id == accountId)
        {

        }
    }
}
