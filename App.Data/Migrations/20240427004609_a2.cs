using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Data.Migrations
{
    /// <inheritdoc />
    public partial class a2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "OrderProduct",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Order",
                newName: "Notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "OrderProduct",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Order",
                newName: "Description");
        }
    }
}
