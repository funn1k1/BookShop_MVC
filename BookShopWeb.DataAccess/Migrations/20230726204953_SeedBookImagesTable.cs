using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShopWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookImages",
                columns: new[] { "Id", "BookId", "CoverImageUrl" },
                values: new object[,]
                {
                    { 1, 1, "https://m.media-amazon.com/images/I/411LNpmcEnL._SX260_.jpg" },
                    { 2, 2, "https://m.media-amazon.com/images/I/41iLDz74c-L._SX397_BO1,204,203,200_.jpg" },
                    { 3, 3, "https://m.media-amazon.com/images/I/41ZzfjIpi0L._SX397_BO1,204,203,200_.jpg" },
                    { 4, 4, "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
