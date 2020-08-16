using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.IdentityServer
{
    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "Flight Log",
                    UserClaims = new List<string> { "flightlog" }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "flightlog", 
                    DisplayName = "FlightLog API", 
                    Description = "Allow the application to access FlightLog APIs on your behalf", 
                    Scopes = new List<string> { "flightlog-api.read", "flightlog-api.write" }, 
                    ApiSecrets = new List<Secret> { new Secret("scopepassword".Sha256()) },
                    UserClaims = new List<string> {"flightlog" }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("flightlog-api.read", "Read Access to the FlightLog API"),
                new ApiScope("flightlog-api.write", "Write Access to the FlightLog API")
            };
        }
    }
}
