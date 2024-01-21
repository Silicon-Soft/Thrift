using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thrift_Us.Migrations
{
    public partial class nnnbvvmnnmmmnnmmbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsViewModelId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailsViewModel_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderDetailsViewModelId",
                table: "OrderDetails",
                column: "OrderDetailsViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsViewModel_OrderHeaderId",
                table: "OrderDetailsViewModel",
                column: "OrderHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderDetailsViewModel_OrderDetailsViewModelId",
                table: "OrderDetails",
                column: "OrderDetailsViewModelId",
                principalTable: "OrderDetailsViewModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderDetailsViewModel_OrderDetailsViewModelId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderDetailsViewModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderDetailsViewModelId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderDetailsViewModelId",
                table: "OrderDetails");
        }
    }
}
