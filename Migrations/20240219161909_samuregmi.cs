using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thrift_Us.Migrations
{
    public partial class samuregmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "RentalViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "RentalViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RentalViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "RentalViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "RentalViewModel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "RentalViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "RentalViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "RentalViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "RentalViewModel");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "RentalViewModel");
        }
    }
}
