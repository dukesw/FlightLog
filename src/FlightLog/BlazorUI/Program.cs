using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DukeSoftware.FlightLog.FlightLogUI.Authorisation;

namespace DukeSoftware.FlightLog.FlightLogUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["FlightLogApiUri"]) });
            builder.Services.AddScoped<FlightLogAuthorisationMessageHandler>();

            builder.Services.AddHttpClient("FlightLogAPI",
                client => client.BaseAddress = new Uri(builder.Configuration["FlightLogApiUri"]))
                    .AddHttpMessageHandler<FlightLogAuthorisationMessageHandler>();

            //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
            //    .CreateClient("WebApi"));

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";

            });
            //builder.Services.AddApiAuthorization();
            
            await builder.Build().RunAsync();
        }
    }
}
