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
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "customAPI", 
                    DisplayName = "API One", 
                    Description = "Allow the application to access APO One on your behalf", 
                    Scopes = new List<string> { "api1.read", "api1.write" }, 
                    ApiSecrets = new List<Secret> { new Secret("scopepassword".Sha256()) },
                    UserClaims = new List<string> {"role" }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1.read", "Read Access to API One"),
                new ApiScope("api1.write", "Write Access to API One")
            };
        }
    }
}
