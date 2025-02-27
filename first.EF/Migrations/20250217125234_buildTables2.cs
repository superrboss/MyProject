using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace first.EF.Migrations
{
    /// <inheritdoc />
    public partial class buildTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "productOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "productOrders");

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
