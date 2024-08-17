using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Dashboard.Migrations
{
    /// <inheritdoc />
    public partial class fixedOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "OrderProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId1",
                table: "OrderProducts",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId1",
                table: "OrderProducts",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId1",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ProductId1",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "OrderProducts");
        }
    }
}
