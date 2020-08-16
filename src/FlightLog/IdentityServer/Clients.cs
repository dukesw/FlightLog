using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.IdentityServer
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                //new Client
                //{
                //    ClientId = "oauthClient",
                //    ClientName = "Example with client credentials",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = new List<Secret> { new Secret("password".Sha256()) },   // change me...
                //    AllowedScopes = new List<string> { "api1.read" }
                //}, 
                new Client
                {
                    ClientId = "flightlog-app", 
                    ClientName = "Flight Log", 
                    ClientSecrets = new List<Secret> { new Secret("passwordtochange".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code, 
                    RedirectUris = new List<string> { "http://localhost:4200/auth-callback" }, 
                    PostLogoutRedirectUris = new List<string> { "http://localhost:4200/" },
                    
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId, 
                        IdentityServerConstants.StandardScopes.Profile, 
                        IdentityServerConstants.StandardScopes.Email, 
                        "role", 
                        "flightlog-api.read",
                        "flightlog-api.write"
                    },
                    AllowedCorsOrigins = new List<string> { "http://localhost:4200", "https://flightlogui.azurewebsites.net" },
                    RequirePkce = true, 
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}
