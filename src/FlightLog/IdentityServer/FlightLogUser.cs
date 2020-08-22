using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.IdentityServer
{
    public class FlightLogUser : IdentityUser
    {
        public FlightLogUser(string userName) : base(userName) { }

        public int AccountId { get; set; }
    }
}
