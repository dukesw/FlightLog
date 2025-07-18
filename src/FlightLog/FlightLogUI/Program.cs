using DukeSoftware.FlightLog.FlightLogUI;
using DukeSoftware.FlightLog.FlightLogUI.Authorisation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
//using System.Net.Http;
using Microsoft.AspNetCore.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluentUIComponents();

builder.Services.AddScoped<FlightLogAuthorisationMessageHandler>();

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<HttpContextAccessor>();

builder.Services.AddHttpClient("FlightLogAPI",
    client => client.BaseAddress = new Uri(builder.Configuration["FlightLogApiUri"]))
        .AddHttpMessageHandler<FlightLogAuthorisationMessageHandler>();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("offline_access");
});

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
