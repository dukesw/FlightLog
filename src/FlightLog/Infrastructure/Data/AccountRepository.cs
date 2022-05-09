using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class AccountRepository : EfRepository<Account>, IAccountRepository
    {
        public AccountRepository(FlightLogContext dbContext) : base(dbContext)
        {

        }
    }
}
