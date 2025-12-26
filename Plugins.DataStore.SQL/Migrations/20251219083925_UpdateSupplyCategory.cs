using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplyCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Supplies",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "SupplyId",
                keyValue: 1,
                column: "Category",
                value: "Thức ăn");

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "SupplyId",
                keyValue: 2,
                column: "Category",
                value: "Y tế");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Supplies");
        }
    }
}
