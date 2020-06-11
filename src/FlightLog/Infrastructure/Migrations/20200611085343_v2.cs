using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightTime",
                table: "Flight");

            migrationBuilder.AddColumn<float>(
                name: "FlightMinutes",
                table: "Flight",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightMinutes",
                table: "Flight");

            migrationBuilder.AddColumn<float>(
                name: "FlightTime",
                table: "Flight",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
