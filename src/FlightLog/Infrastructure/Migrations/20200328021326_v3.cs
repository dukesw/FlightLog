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

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCharge_Battery_BatteryId",
                table: "BatteryCharge");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Model_ModelId",
                table: "Flight");

            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "Location",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Lattitude",
                table: "Location",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "BatteryId",
                table: "BatteryCharge",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId",
                table: "Battery",
                column: "BatteryTypeId",
                principalTable: "BatteryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCharge_Battery_BatteryId",
                table: "BatteryCharge",
                column: "BatteryId",
                principalTable: "Battery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Model_ModelId",
                table: "Flight",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId",
                table: "Battery");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCharge_Battery_BatteryId",
                table: "BatteryCharge");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Model_ModelId",
                table: "Flight");

            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "Location",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Lattitude",
                table: "Location",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BatteryId",
                table: "BatteryCharge",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Battery_BatteryType_BatteryTypeId",
                table: "Battery",
                column: "BatteryTypeId",
                principalTable: "BatteryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCharge_Battery_BatteryId",
                table: "BatteryCharge",
                column: "BatteryId",
                principalTable: "Battery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Model_ModelId",
                table: "Flight",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
