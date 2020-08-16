using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.IdentityServer
{
    internal class Users
    {
        public static List<TestUser> Get ()
        {
            return new List<TestUser> 
            {
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(), 
                    Username = "rhys", 
                    Password = "Password1!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "rhys.jones@yahoo.co.nz"), 
                        new Claim(JwtClaimTypes.Role, "flightlog")
                    }
                }
            };
        }
    }
}
