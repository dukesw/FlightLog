﻿// <auto-generated />
using System;
using DukeSoftware.FlightLog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    [DbContext(typeof(FlightLogContext))]
    [Migration("20200611085343_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Battery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatteryNumber")
                        .HasColumnType("int");

                    b.Property<int>("BatteryTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BatteryTypeId");

                    b.ToTable("Battery");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.BatteryCharge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatteryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ChargedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mah")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId");

                    b.ToTable("BatteryCharge");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.BatteryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacityMah")
                        .HasColumnType("int");

                    b.Property<int>("Cells")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeightInGrams")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BatteryType");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BatteryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<float>("FlightMinutes")
                        .HasColumnType("real");

                    b.Property<int>("ModelFlightNumber")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId");

                    b.HasIndex("FieldId");

                    b.HasIndex("ModelId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("Lattitude")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeatherStationLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.MediaLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("Uri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("MediaLink");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MaidenedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PowerPlant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchasedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.PowerPlant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchasedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PowerPlant");
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Battery", b =>
                {
                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.BatteryType", "BatteryType")
                        .WithMany("Batteries")
                        .HasForeignKey("BatteryTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.BatteryCharge", b =>
                {
                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Battery", "Battery")
                        .WithMany()
                        .HasForeignKey("BatteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.Flight", b =>
                {
                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Battery", "Battery")
                        .WithMany()
                        .HasForeignKey("BatteryId");

                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Location", "Field")
                        .WithMany("Flights")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Model", "Model")
                        .WithMany("Flights")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DukeSoftware.FlightLog.ApplicationCore.Entities.MediaLink", b =>
                {
                    b.HasOne("DukeSoftware.FlightLog.ApplicationCore.Entities.Flight", null)
                        .WithMany("MediaLinks")
                        .HasForeignKey("FlightId");
                });
#pragma warning restore 612, 618
        }
    }
}
