using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Battery_BatteryId",
                table: "Flight");

            migrationBuilder.AlterColumn<int>(
                name: "BatteryId",
                table: "Flight",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Battery_BatteryId",
                table: "Flight",
                column: "BatteryId",
                principalTable: "Battery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Battery_BatteryId",
                table: "Flight");

            migrationBuilder.AlterColumn<int>(
                name: "BatteryId",
                table: "Flight",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Battery_BatteryId",
                table: "Flight",
                column: "BatteryId",
                principalTable: "Battery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
