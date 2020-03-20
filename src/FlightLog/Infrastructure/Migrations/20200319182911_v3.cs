using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId",
                table: "Battery");

            migrationBuilder.AlterColumn<long>(
                name: "BatteryTypeId",
                table: "Battery",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId",
                table: "Battery",
                column: "BatteryTypeId",
                principalTable: "BatteryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId",
                table: "Battery");

            migrationBuilder.AlterColumn<long>(
                name: "BatteryTypeId",
                table: "Battery",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId",
                table: "Battery",
                column: "BatteryTypeId",
                principalTable: "BatteryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
