using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NLayerApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Company", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Nokia", "Nokia Lumia 630", 220m },
                    { 2, "Apple", "iPhone 6", 320m },
                    { 3, "LG", "LG G4", 260m },
                    { 4, "Samsung", "Samsung Galaxy S6", 300m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
