using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Mapper;
using DukeSoftware.FlightLog.ApplicationCore.Services;
using DukeSoftware.FlightLog.Infrastructure;
using DukeSoftware.FlightLog.Infrastructure.Data;
using DukeSoftware.FlightLog.Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace Web
{
    public class Startup
    {

        private readonly string MyAllowSpecificOrigins = "localdev";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<FlightLogContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FlightLog")));

            // Services and repositories
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IBatteryRepository, BatteryRepository>();
            services.AddScoped<IBatteryTypeRepository, BatteryTypeRepository>();
            services.AddScoped<IBatteryChargeRepository, BatteryChargeRepository>();
            services.AddScoped<IBatteryService, BatteryService>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>(); 
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddControllers()
                //.AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                //.AddNewtonsoftJson(options => options.SerializerSettings.MaxDepth = 1)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new DefaultNamingStrategy() });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

            services.AddAutoMapper(typeof(FlightProfile));
            //services.AddAutoMapper(Assembly.LoadFrom("DukeSoftware.FlightLog.ApplicationCore"));

            // TODO How to add .AddNewtonsoftJson(options => options.SerializerSettings.TypeNameHandling.)


            // TODO How to add .AddNewtonsoftJson(options => options.SerializerSettings.TypeNameHandling.)

            services.AddAuthorization();
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:5001";
                    //options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
                }
                );
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
