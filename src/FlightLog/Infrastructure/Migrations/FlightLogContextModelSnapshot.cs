﻿// <auto-generated />
using System;
using DukeSoftware.FlightLog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    [DbContext(typeof(FlightLogContext))]
    partial class FlightLogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Battery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BatteryTypeId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("Id");

                    b.HasIndex("BatteryTypeId");

                    b.ToTable("Battery");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.BatteryType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacityMah");

                    b.Property<int>("Cells");

                    b.Property<string>("Type");

                    b.Property<int>("WeightInGrams");

                    b.HasKey("Id");

                    b.ToTable("BatteryType");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Flight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BatteryId");

                    b.Property<DateTime>("Date");

                    b.Property<long?>("FieldId");

                    b.Property<long?>("FlyingOnId");

                    b.Property<string>("Footage");

                    b.Property<long?>("ModelId");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId");

                    b.HasIndex("FieldId");

                    b.HasIndex("FlyingOnId");

                    b.HasIndex("ModelId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Lattitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("WeatherStation");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Model", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MaidenedOn");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<long?>("PowerPlantId");

                    b.Property<DateTime>("PurchasedOn");

                    b.HasKey("Id");

                    b.HasIndex("PowerPlantId");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.PowerPlant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("PurchasedOn");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("PowerPlant");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Battery", b =>
                {
                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.BatteryType", "BatteryType")
                        .WithMany()
                        .HasForeignKey("BatteryTypeId");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Flight", b =>
                {
                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Battery", "Battery")
                        .WithMany()
                        .HasForeignKey("BatteryId");

                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Location", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId");

                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.PowerPlant", "FlyingOn")
                        .WithMany()
                        .HasForeignKey("FlyingOnId");

                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Model", b =>
                {
                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.PowerPlant", "PowerPlant")
                        .WithMany()
                        .HasForeignKey("PowerPlantId");
                });
#pragma warning restore 612, 618
        }
    }
}
