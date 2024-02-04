using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thrift_Us.Migrations
{
    public partial class samikshyasamikshyaregmisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Rentals_RentalId",
                table: "OrderHeaders");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Rentals_RentalId",
                table: "OrderHeaders",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Rentals_RentalId",
                table: "OrderHeaders");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Rentals_RentalId",
                table: "OrderHeaders",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
