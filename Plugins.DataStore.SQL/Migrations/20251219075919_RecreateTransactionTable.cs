using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class RecreateTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "FarmId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "FarmId",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "SupplyTransactions",
                columns: table => new
                {
                    SupplyTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplyId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyTransactions", x => x.SupplyTransactionId);
                    table.ForeignKey(
                        name: "FK_SupplyTransactions_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "SupplyId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyTransactions_SupplyId",
                table: "SupplyTransactions",
                column: "SupplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplyTransactions");

            migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "FarmId", "Address", "Name", "OwnerName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "Trại Heo Ba Vì", "Nguyễn Văn A", "" },
                    { 2, "Sơn La", "Trại Bò Mộc Châu", "Trần Thị B", "" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "FarmId", "HealthStatus", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 12, 1, "Khỏe mạnh", "Heo 01", "Heo" },
                    { 2, 24, 2, "Khỏe mạnh", "Bò 01", "Bò" }
                });
        }
    }
}
