using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thrift_Us.Migrations
{
    public partial class samumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentalViewModel");

            migrationBuilder.AddColumn<decimal>(
                name: "PerDay",
                table: "RentalViewModel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PerDay",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerDay",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "PerDay",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "RentalViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RentalViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
