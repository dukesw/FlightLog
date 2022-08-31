using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLogType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightFlightTag",
                columns: table => new
                {
                    FlightsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightFlightTag", x => new { x.FlightsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_FlightFlightTag_Flight_FlightsId",
                        column: x => x.FlightsId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightFlightTag_FlightTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "FlightTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceLog_MaintenanceLogType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MaintenanceLogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceLog_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightFlightTag_TagsId",
                table: "FlightFlightTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_ModelId",
                table: "MaintenanceLog",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_TypeId",
                table: "MaintenanceLog",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightFlightTag");

            migrationBuilder.DropTable(
                name: "MaintenanceLog");

            migrationBuilder.DropTable(
                name: "FlightTag");

            migrationBuilder.DropTable(
                name: "MaintenanceLogType");
        }
    }
}
