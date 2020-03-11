using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BatteryTypeId1",
                table: "Battery",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Battery_BatteryTypeId1",
                table: "Battery",
                column: "BatteryTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId1",
                table: "Battery",
                column: "BatteryTypeId1",
                principalTable: "BatteryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId1",
                table: "Battery");

            migrationBuilder.DropIndex(
                name: "IX_Battery_BatteryTypeId1",
                table: "Battery");

            migrationBuilder.DropColumn(
                name: "BatteryTypeId1",
                table: "Battery");
        }
    }
}
