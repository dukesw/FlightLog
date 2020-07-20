using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DukeSoftware.FlightLog.ApplicationCore.IdentityServer
{
    public class Startup
    {
        const string connectionString = "Server=localhost\\SQL2016dev;Database=IdentityServer;User=sa;Password=Password1!;MultipleActiveResultSets=true";
        string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FlightLogIdentityDbContext>(builder =>
                builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<FlightLogIdentityDbContext>();

            services.AddIdentityServer()
                //.AddInMemoryClients(Clients.Get())
                //.AddInMemoryIdentityResources(Resources.GetIdentityResources())
                //.AddInMemoryApiResources(Resources.GetApiResources())
                //.AddInMemoryApiScopes(Resources.GetApiScopes())
                //.AddTestUsers(Users.Get())
                .AddDeveloperSigningCredential()
            .AddConfigurationStore(options => options.ConfigureDbContext =
                builder => builder.UseSqlServer(
                    connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
            .AddOperationalStore(options => options.ConfigureDbContext =
                builder => builder.UseSqlServer(
                    connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
            .AddAspNetIdentity<IdentityUser>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SetUpTestUsers(app);

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

            ////app.UseEndpoints(endpoints =>
            ////{
            ////    endpoints.MapGet("/", async context =>
            ////    {
            ////        await context.Response.WriteAsync("Hello World!");
            ////    });
            ////});
        }

        private void SetUpTestUsers(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                ///---
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();



                if (!context.Clients.Any())
                {
                    foreach (var client in Clients.Get())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Resources.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var scope in Resources.GetApiScopes())
                    {
                        context.ApiScopes.Add(scope.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Resources.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                ///---


                // Adding a user manually to the EF store
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var tempClaims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "rhys.jones@yahoo.co.nz"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    };

                var identityUser = new IdentityUser("rhys");
                identityUser.Id = Guid.NewGuid().ToString();
                userManager.CreateAsync(identityUser, "Password1!").Wait();
                userManager.AddClaimsAsync(identityUser, tempClaims.ToList()).Wait();
            }
        }

        private void SetUpClient(IApplicationBuilder app)
        {

        }

    }
}
