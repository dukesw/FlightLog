using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FlightLogContext>
    {
        public FlightLogContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<FlightLogContext>();
            var connectionString = configuration.GetConnectionString("FlightLog");
            builder.UseSqlServer(connectionString);

            return new FlightLogContext(builder.Options);

        }
    }
}
