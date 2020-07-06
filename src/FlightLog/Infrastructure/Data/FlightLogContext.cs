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
        public DbSet<MediaLink> MediaLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BatteryType>(ConfigureBatteryType);
            builder.Entity<Battery>(ConfigureBattery);
            builder.Entity<BatteryCharge>(ConfigureBatteryCharges);
            builder.Entity<Location>(ConfigureLocation);
            builder.Entity<PowerPlant>(ConfigurePowerPlant);
            builder.Entity<Model>(ConfigureModel);
            builder.Entity<Flight>(ConfigureFlight);
            builder.Entity<MediaLink>(ConfigureMediaLinks);
            builder.Entity<Pilot>(ConfigurePilot);
        }

        private void ConfigureMediaLinks(EntityTypeBuilder<MediaLink> builder)
        {
            builder.ToTable("MediaLink");
        }

        private void ConfigureBattery(EntityTypeBuilder<Battery> builder)
        {

            builder.ToTable("Battery")
                .HasOne<BatteryType>(t => t.BatteryType)
                .WithMany(b => b.Batteries)
                .HasForeignKey(b => b.BatteryTypeId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }

        private void ConfigureBatteryCharges(EntityTypeBuilder<BatteryCharge> builder)
        {
            builder.ToTable("BatteryCharge");
        }

        private void ConfigureBatteryType(EntityTypeBuilder<BatteryType> builder)
        {
            builder.ToTable("BatteryType")
                .HasMany<Battery>(t => t.Batteries)
                .WithOne(b => b.BatteryType)
                .OnDelete(DeleteBehavior.Restrict);
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
            builder.ToTable("Model")
                .HasMany<Flight>(x => x.Flights)
                .WithOne(x => x.Model)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureFlight(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flight")
                .HasOne<Model>(x => x.Model)
                .WithMany(x => x.Flights)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Location>(x => x.Field)
                .WithMany(x => x.Flights);

            builder.HasOne<Pilot>(x => x.Pilot)
                .WithMany(x => x.Flights);
                

        }

        private void ConfigurePilot(EntityTypeBuilder<Pilot> builder)
        {
            builder.ToTable("Pilot")
                .HasMany<Flight>(x => x.Flights)
                .WithOne(x => x.Pilot)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
