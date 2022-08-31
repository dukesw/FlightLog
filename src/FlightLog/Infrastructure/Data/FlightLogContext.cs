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
        public DbSet<ModelStatus> ModelStatuses { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        public DbSet<MaintenanceLogType> MaintenanceLogTypes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightTag> FlightTags {get; set;}
        public DbSet<MediaLink> MediaLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BatteryType>(ConfigureBatteryType);
            builder.Entity<Battery>(ConfigureBattery);
            builder.Entity<BatteryCharge>(ConfigureBatteryCharges);
            builder.Entity<Location>(ConfigureLocation);
            builder.Entity<PowerPlant>(ConfigurePowerPlant);
            builder.Entity<Model>(ConfigureModel);
            builder.Entity<ModelStatus>(ConfigureModelStatus);
            builder.Entity<Flight>(ConfigureFlight);
            builder.Entity<FlightTag>(ConfigureFlightTag);
            builder.Entity<MediaLink>(ConfigureMediaLinks);
            builder.Entity<Pilot>(ConfigurePilot);
            builder.Entity<MaintenanceLog>(ConfigureMaintenanceLog);
            builder.Entity<MaintenanceLogType>(ConfigureMaintenanceLogType);
        }

        private void ConfigureMediaLinks(EntityTypeBuilder<MediaLink> builder)
        {
            builder.ToTable("MediaLink")
                .HasOne<Account>(x => x.Account)
                .WithMany(x => x.MediaLinks);

        }

        private void ConfigureBattery(EntityTypeBuilder<Battery> builder)
        {

            builder.ToTable("Battery")
                .HasOne<BatteryType>(t => t.BatteryType)
                .WithMany(b => b.Batteries)
                .HasForeignKey(b => b.BatteryTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Account>(x => x.Account)
                .WithMany(x => x.Batteries);

        }

        private void ConfigureBatteryCharges(EntityTypeBuilder<BatteryCharge> builder)
        {
            builder.ToTable("BatteryCharge")
                .HasOne<Account>(x => x.Account)
                .WithMany(x => x.BatteryCharges);
            
        }

        private void ConfigureBatteryType(EntityTypeBuilder<BatteryType> builder)
        {
            builder.ToTable("BatteryType")
                .HasMany<Battery>(t => t.Batteries)
                .WithOne(b => b.BatteryType)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Account>(x => x.Account)
                .WithMany(x => x.BatteryTypes);

        }

        private void ConfigureLocation(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location")
                .HasOne<Account>(x => x.Account)
                .WithMany(x => x.Fields);

        }

        private void ConfigurePowerPlant(EntityTypeBuilder<PowerPlant> builder)
        {
            builder.ToTable("PowerPlant")
                .HasOne<Account>(x => x.Account)
                .WithMany(x => x.PowerPlants);

        }

        private void ConfigureModel(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model")
                .HasMany<Flight>(x => x.Flights)
                .WithOne(x => x.Model)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Account>(x => x.Account)
                .WithMany(x => x.Models);

            builder.HasOne<ModelStatus>(x => x.Status)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<MaintenanceLog>(x => x.MaintenanceLogs)
                .WithOne(x => x.Model)
                .OnDelete(DeleteBehavior.Restrict);

        }

        private void ConfigureModelStatus(EntityTypeBuilder<ModelStatus> builder)
        {
            builder.ToTable("ModelStatus");
                //.HasMany<Model>(x => x.Models)
                //.WithOne(x => x.Status)
                //.OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureMaintenanceLog(EntityTypeBuilder<MaintenanceLog> builder)
        {
            builder.ToTable("MaintenanceLog");

            //.HasMany<Model>(x => x.Models)
            //.WithOne(x => x.Status)
            //.OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<MaintenanceLogType>(x => x.Type);
        }
        private void ConfigureMaintenanceLogType(EntityTypeBuilder<MaintenanceLogType> builder)
        {
            builder.ToTable("MaintenanceLogType");
            //.HasMany<Model>(x => x.Models)
            //.WithOne(x => x.Status)
            //.OnDelete(DeleteBehavior.Restrict);
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

            builder.HasOne<Account>(x => x.Account)
                .WithMany(x => x.Flights);

            builder.HasMany<FlightTag>(x => x.Tags)
                .WithMany(x => x.Flights);// (""); // Testing - trying to get DB wired
             //   .UsingEntity(x => x.ToTable("FlightToFlightTag"));

            builder.Navigation(x => x.Tags)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

        }

        private void ConfigureFlightTag(EntityTypeBuilder<FlightTag> builder)
        {
            builder.ToTable("FlightTag");
                //Tyi it.Ignore("FlightId");
            //.HasMany<Model>(x => x.Models)
            //.WithOne(x => x.Status)
            //.OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigurePilot(EntityTypeBuilder<Pilot> builder)
        {
            builder.ToTable("Pilot")
                .HasMany<Flight>(x => x.Flights)
                .WithOne(x => x.Pilot)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Account>(x => x.Account)
                .WithMany(x => x.Pilots);

        }
    }
}
