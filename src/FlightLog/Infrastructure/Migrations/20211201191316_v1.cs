using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerEmail = table.Column<string>(type: "TEXT", nullable: true),
                    OpenedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClosedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatteryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    CapacityMah = table.Column<int>(type: "INTEGER", nullable: false),
                    Cells = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    WeightInGrams = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryType_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Lattitude = table.Column<float>(type: "REAL", nullable: true),
                    Longitude = table.Column<float>(type: "REAL", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherStationLink = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Registration = table.Column<string>(type: "TEXT", nullable: true),
                    Club = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pilot_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerPlant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    PurchasedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerPlant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerPlant_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    PowerPlant = table.Column<string>(type: "TEXT", nullable: true),
                    PurchasedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MaidenedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DisposedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModelStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalFlights = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Model_ModelStatus_ModelStatusId",
                        column: x => x.ModelStatusId,
                        principalTable: "ModelStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Battery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatteryNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    BatteryTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battery_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Battery_BatteryType_BatteryTypeId",
                        column: x => x.BatteryTypeId,
                        principalTable: "BatteryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatteryCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChargedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Mah = table.Column<int>(type: "INTEGER", nullable: false),
                    BatteryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryCharge_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatteryCharge_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModelFlightNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatteryId = table.Column<int>(type: "INTEGER", nullable: true),
                    PilotId = table.Column<int>(type: "INTEGER", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    FlightMinutes = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Location_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Pilot_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Uri = table.Column<string>(type: "TEXT", nullable: true),
                    FlightId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaLink_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaLink_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battery_AccountId",
                table: "Battery",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Battery_BatteryTypeId",
                table: "Battery",
                column: "BatteryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCharge_AccountId",
                table: "BatteryCharge",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCharge_BatteryId",
                table: "BatteryCharge",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryType_AccountId",
                table: "BatteryType",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AccountId",
                table: "Flight",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_BatteryId",
                table: "Flight",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FieldId",
                table: "Flight",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ModelId",
                table: "Flight",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PilotId",
                table: "Flight",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_AccountId",
                table: "Location",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLink_AccountId",
                table: "MediaLink",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLink_FlightId",
                table: "MediaLink",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_AccountId",
                table: "Model",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_ModelStatusId",
                table: "Model",
                column: "ModelStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pilot_AccountId",
                table: "Pilot",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerPlant_AccountId",
                table: "PowerPlant",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryCharge");

            migrationBuilder.DropTable(
                name: "MediaLink");

            migrationBuilder.DropTable(
                name: "PowerPlant");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Battery");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "BatteryType");

            migrationBuilder.DropTable(
                name: "ModelStatus");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
