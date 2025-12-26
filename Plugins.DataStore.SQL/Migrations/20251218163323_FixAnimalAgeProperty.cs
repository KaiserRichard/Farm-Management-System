using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class FixAnimalAgeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeMonths",
                table: "Animals",
                newName: "Age");

            migrationBuilder.AlterColumn<string>(
                name: "Species",
                table: "Animals",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HealthStatus",
                table: "Animals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "HealthStatus",
                value: "Khỏe mạnh");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "HealthStatus",
                value: "Khỏe mạnh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthStatus",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Animals",
                newName: "AgeMonths");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Species",
                keyValue: null,
                column: "Species",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Species",
                table: "Animals",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
