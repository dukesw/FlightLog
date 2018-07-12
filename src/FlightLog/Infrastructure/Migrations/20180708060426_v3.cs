using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
