using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace DukeSoftware.FlightLog.FlightLogUI.Authorisation
{
    public class FlightLogAuthorisationMessageHandler : AuthorizationMessageHandler
    {   
        public FlightLogAuthorisationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigationManager)
        : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://localhost:5002", "https://flightlogapi.azurewebsites.net" },
                scopes: new[] { "flightlog-api.read", "flightlog-api.write" });
        }
    }
}
