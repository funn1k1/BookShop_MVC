using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShopWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableQuantity", "CoverImageUrl", "Description", "DiscountedPrice", "ISBN", "ListPrice", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "Valerio De Sanctis", 100, "https://m.media-amazon.com/images/I/411LNpmcEnL._SX260_.jpg", "Building Web APIs with ASP.NET Core is a practical beginner’s guide to creating your first web APIs using ASP.NET Core. In it, you’ll develop an API that feeds web-based services, including websites and mobile apps, for a board games application. The book is cleverly structured to mirror a real-world development project, with each chapter introducing a new feature request. You’ll build your API with an ecosystem of ASP.NET Core tools that help simplify everything from setting up your data model to generating documentation", null, "9781633439481", 47.50m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building Web APIs with ASP.NET Core" },
                    { 2, "Jon Skeet", 100, null, "Building Web APIs with ASP.NET Core is a practical beginner’s guide to creating your first web APIs using ASP.NET Core. In it, you’ll develop an API that feeds web-based services, including websites and mobile apps, for a board games application. The book is cleverly structured to mirror a real-world development project, with each chapter introducing a new feature request. You’ll build your API with an ecosystem of ASP.NET Core tools that help simplify everything from setting up your data model to generating documentation", null, "9781617294532", 38.99m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# in Depth" },
                    { 3, "Andrew Lock", 100, "https://d374oxlv7wyffd.cloudfront.net/B0977Z1DHC/f2ea5a9a/cover.jpeg", "ASP.NET Core in Action, Second Edition is a comprehensive guide to creating web applications with ASP.NET Core 5.0. Go from basic HTTP concepts to advanced framework customization. Illustrations and annotated code make learning visual and easy. Master logins, dependency injection, security, and more. This updated edition covers the latest features, including Razor Pages and the new hosting paradigm", null, "9781617298301", 50.99m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core in Action, Second Edition" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
