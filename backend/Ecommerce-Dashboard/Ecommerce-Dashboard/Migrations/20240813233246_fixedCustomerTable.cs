using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Dashboard.Migrations
{
    /// <inheritdoc />
    public partial class fixedCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Customers",
                newName: "country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "country",
                table: "Customers",
                newName: "PasswordHash");
        }
    }
}
