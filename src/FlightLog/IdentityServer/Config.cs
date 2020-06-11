using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> { 
                new ApiResource("flightlog-api", "FlightLog API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                // API Access
                new Client { 
                    ClientId = "flightlog-api-client", 
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("mysecret".Sha256()) }, 
                    AllowedScopes = { "flightlog-api" }, 
                }, 
                // Application Access
                new Client
                {
                    ClientId = "flightlog-app-client", 
                    AllowedGrantTypes = GrantTypes.Code, 
                    ClientSecrets = { new Secret("appsecret".Sha256()) },
                    RequirePkce = false,
                    RedirectUris = { "https://localhost:5002/signin-oidc" }, 
                    AllowedScopes = new List<String> { 
                        IdentityServerConstants.StandardScopes.OpenId, 
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}
