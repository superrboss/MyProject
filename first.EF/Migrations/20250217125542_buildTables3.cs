using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace first.EF.Migrations
{
    /// <inheritdoc />
    public partial class buildTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCount",
                table: "productOrders",
                newName: "ProductQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "productOrders",
                newName: "ProductCount");
        }
    }
}
