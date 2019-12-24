using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatteryNumber",
                table: "Battery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BatteryCharge",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChargedOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Mah = table.Column<int>(nullable: false),
                    BatteryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryCharge_Battery_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryCharge_BatteryId",
                table: "BatteryCharge",
                column: "BatteryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryCharge");

            migrationBuilder.DropColumn(
                name: "BatteryNumber",
                table: "Battery");
        }
    }
}
