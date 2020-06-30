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
                    ClientName = "Flight Log",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    ClientSecrets = { new Secret("appsecret".Sha256()) },
                    //RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris = { "http://localhost:4200/auth-callback" },
                    PostLogoutRedirectUris = {"http://localhost:4200/"},
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowedScopes = new List<String> {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile, 
                        IdentityServerConstants.StandardScopes.Email, 
                        "flightlog-api"
                    },
                    AllowAccessTokensViaBrowser = true, 
                    AccessTokenLifetime = 3600
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                // some standard scopes from the OIDC spec
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()

                //// custom identity resource with some consolidated claims
                //new IdentityResource("custom.profile", new[] { JwtClaimTypes.Name, JwtClaimTypes.Email, "location" })
            };
        }
    }
}
