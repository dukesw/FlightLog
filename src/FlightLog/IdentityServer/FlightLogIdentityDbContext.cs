using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.IdentityServer
{
    public class FlightLogIdentityDbContext : IdentityDbContext<FlightLogUser>
    {
        public FlightLogIdentityDbContext(DbContextOptions<FlightLogIdentityDbContext> options) : base(options) { }
    }
}
