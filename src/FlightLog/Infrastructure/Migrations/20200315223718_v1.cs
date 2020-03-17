using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacityMah = table.Column<int>(nullable: false),
                    Cells = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    WeightInGrams = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Lattitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    WeatherStation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerPlant",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    PurchasedOn = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerPlant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battery",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatteryNumber = table.Column<int>(nullable: false),
                    BatteryTypeId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battery_BatteryType_BatteryTypeId",
                        column: x => x.BatteryTypeId,
                        principalTable: "BatteryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    PowerPlantId = table.Column<long>(nullable: true),
                    PurchasedOn = table.Column<DateTime>(nullable: false),
                    MaidenedOn = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_PowerPlant_PowerPlantId",
                        column: x => x.PowerPlantId,
                        principalTable: "PowerPlant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatteryCharge",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargedOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Mah = table.Column<int>(nullable: false),
                    BatteryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryCharge_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    FieldId = table.Column<long>(nullable: true),
                    ModelId = table.Column<long>(nullable: true),
                    BatteryId = table.Column<long>(nullable: true),
                    FlyingOnId = table.Column<long>(nullable: true),
                    Footage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Location_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_PowerPlant_FlyingOnId",
                        column: x => x.FlyingOnId,
                        principalTable: "PowerPlant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battery_BatteryTypeId",
                table: "Battery",
                column: "BatteryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCharge_BatteryId",
                table: "BatteryCharge",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_BatteryId",
                table: "Flight",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FieldId",
                table: "Flight",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FlyingOnId",
                table: "Flight",
                column: "FlyingOnId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ModelId",
                table: "Flight",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_PowerPlantId",
                table: "Model",
                column: "PowerPlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryCharge");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Battery");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "BatteryType");

            migrationBuilder.DropTable(
                name: "PowerPlant");
        }
    }
}
