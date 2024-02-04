using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thrift_Us.Migrations
{
    public partial class samikshyasamikshyar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RentalPrice",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_RentalId",
                table: "OrderHeaders",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Rentals_RentalId",
                table: "OrderHeaders",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Rentals_RentalId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_RentalId",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "RentalPrice",
                table: "OrderDetails");
        }
    }
}
