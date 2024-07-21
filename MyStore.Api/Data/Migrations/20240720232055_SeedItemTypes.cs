using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyStore.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedItemTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Game" },
                    { 2, "Movie" },
                    { 3, "SportsItem" },
                    { 4, "Food" },
                    { 5, "Electronics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
