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
                    SubjectId = "37E84366-A840-4974-A2B3-98E4FCC30936", 
                    Username = "rhys", 
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "rhys.jones@yahoo.co.nz"), 
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
