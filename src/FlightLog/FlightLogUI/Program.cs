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
using Microsoft.AspNetCore.Http;
using Radzen;

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


           // builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<HttpContextAccessor>();


            builder.Services.AddHttpClient("FlightLogAPI",
                client => client.BaseAddress = new Uri(builder.Configuration["FlightLogApiUri"]))
                    .AddHttpMessageHandler<FlightLogAuthorisationMessageHandler>();

            //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
            //    .CreateClient("WebApi"));

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.DefaultScopes.Add("profile");
                options.ProviderOptions.DefaultScopes.Add("offline_access");    // For Refresh token

            });
            //builder.Services.AddApiAuthorization();
            
            await builder.Build().RunAsync();
        }
    }
}
