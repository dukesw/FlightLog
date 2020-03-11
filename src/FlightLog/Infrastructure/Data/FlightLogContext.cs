using DukeSoftware.FlightLog.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class FlightLogContext : DbContext
    {
        public FlightLogContext(DbContextOptions<FlightLogContext> options) : base(options)
        { }

        public DbSet<BatteryType> BatteryTypes { get; set; }
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<BatteryCharge> BatteryCharges { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PowerPlant> PowerPlants { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BatteryType>(ConfigureBatteryType);
            builder.Entity<Battery>(ConfigureBattery);
            builder.Entity<BatteryCharge>(ConfigureBatteryCharges);
            builder.Entity<Location>(ConfigureLocation);
            builder.Entity<PowerPlant>(ConfigurePowerPlant);
            builder.Entity<Model>(ConfigureModel);
            builder.Entity<Flight>(ConfigureFlight);

        }

        private void ConfigureBattery(EntityTypeBuilder<Battery> builder)
        {
            builder.ToTable("Battery")
                .HasOne<BatteryType>(t => t.BatteryType)
                .WithMany(); 
                
        }

        private void ConfigureBatteryCharges(EntityTypeBuilder<BatteryCharge> builder)
        {
            builder.ToTable("BatteryCharge");
        }

        private void ConfigureBatteryType(EntityTypeBuilder<BatteryType> builder)
        {
            builder.ToTable("BatteryType"); 
                //HasMany<Battery>(t => t.Batteries);
                //.WithOne(b => b.BatteryType);
        }

        private void ConfigureLocation(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");
        }

        private void ConfigurePowerPlant(EntityTypeBuilder<PowerPlant> builder)
        {
            builder.ToTable("PowerPlant");
        }

        private void ConfigureModel(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model");
        }

        private void ConfigureFlight(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flight");
        }
    }
}
