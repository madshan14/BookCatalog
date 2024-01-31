using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookCatalog.Migrations
{
    /// <inheritdoc />
    public partial class WithSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "PublishDateUtc", "Title" },
                values: new object[,]
                {
                    { 1L, "Japanese Manga", new DateTime(2024, 1, 31, 7, 10, 29, 201, DateTimeKind.Utc).AddTicks(9295), "One Piece" },
                    { 2L, "Romance", new DateTime(2024, 1, 31, 7, 10, 29, 201, DateTimeKind.Utc).AddTicks(9298), "Titanic" },
                    { 3L, "Cartoon", new DateTime(2024, 1, 31, 7, 10, 29, 201, DateTimeKind.Utc).AddTicks(9299), "Doraemon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
