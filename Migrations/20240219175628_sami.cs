using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thrift_Us.Migrations
{
    public partial class sami : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerDay",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "PerDay",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "RentalViewModel",
                newName: "RentalPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentalPrice",
                table: "RentalViewModel",
                newName: "Price");

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
    }
}
