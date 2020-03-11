using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v5 : Migration
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
                name: "FK_Flight_Battery_BatteryId",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatteryType",
                table: "BatteryType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battery",
                table: "Battery");

            migrationBuilder.RenameTable(
                name: "BatteryType",
                newName: "BatteryTypes");

            migrationBuilder.RenameTable(
                name: "Battery",
                newName: "Batteries");

            migrationBuilder.RenameIndex(
                name: "IX_Battery_BatteryTypeId",
                table: "Batteries",
                newName: "IX_Batteries_BatteryTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatteryTypes",
                table: "BatteryTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batteries",
                table: "Batteries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batteries_BatteryTypes_BatteryTypeId",
                table: "Batteries",
                column: "BatteryTypeId",
                principalTable: "BatteryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryCharge_Batteries_BatteryId",
                table: "BatteryCharge",
                column: "BatteryId",
                principalTable: "Batteries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Batteries_BatteryId",
                table: "Flight",
                column: "BatteryId",
                principalTable: "Batteries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batteries_BatteryTypes_BatteryTypeId",
                table: "Batteries");

            migrationBuilder.DropForeignKey(
                name: "FK_BatteryCharge_Batteries_BatteryId",
                table: "BatteryCharge");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Batteries_BatteryId",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatteryTypes",
                table: "BatteryTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batteries",
                table: "Batteries");

            migrationBuilder.RenameTable(
                name: "BatteryTypes",
                newName: "BatteryType");

            migrationBuilder.RenameTable(
                name: "Batteries",
                newName: "Battery");

            migrationBuilder.RenameIndex(
                name: "IX_Batteries_BatteryTypeId",
                table: "Battery",
                newName: "IX_Battery_BatteryTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatteryType",
                table: "BatteryType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battery",
                table: "Battery",
                column: "Id");

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Battery_BatteryId",
                table: "Flight",
                column: "BatteryId",
                principalTable: "Battery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
