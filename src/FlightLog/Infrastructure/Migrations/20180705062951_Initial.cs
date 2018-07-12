using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DukeSoftware.FlightLog.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CapacityMah = table.Column<int>(nullable: false),
                    Cells = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    WeightInGrams = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battery",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BatteryTypeId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battery_BatteryType_BatteryTypeId",
                        column: x => x.BatteryTypeId,
                        principalTable: "BatteryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battery_BatteryTypeId",
                table: "Battery",
                column: "BatteryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battery");

            migrationBuilder.DropTable(
                name: "BatteryType");
        }
    }
}
