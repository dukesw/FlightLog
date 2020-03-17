using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_PowerPlant_FlyingOnId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Model_PowerPlant_PowerPlantId",
                table: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Model_PowerPlantId",
                table: "Model");

            migrationBuilder.DropIndex(
                name: "IX_Flight_FlyingOnId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "PowerPlantId",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "FlyingOnId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Footage",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Flight");

            migrationBuilder.AddColumn<string>(
                name: "PowerPlant",
                table: "Model",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FlightTime",
                table: "Flight",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "ModelFlightNumber",
                table: "Flight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MediaLink",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(nullable: true),
                    FlightId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaLink_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaLink_FlightId",
                table: "MediaLink",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaLink");

            migrationBuilder.DropColumn(
                name: "PowerPlant",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "FlightTime",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ModelFlightNumber",
                table: "Flight");

            migrationBuilder.AddColumn<long>(
                name: "PowerPlantId",
                table: "Model",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FlyingOnId",
                table: "Flight",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Footage",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Model_PowerPlantId",
                table: "Model",
                column: "PowerPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FlyingOnId",
                table: "Flight",
                column: "FlyingOnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_PowerPlant_FlyingOnId",
                table: "Flight",
                column: "FlyingOnId",
                principalTable: "PowerPlant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_PowerPlant_PowerPlantId",
                table: "Model",
                column: "PowerPlantId",
                principalTable: "PowerPlant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
