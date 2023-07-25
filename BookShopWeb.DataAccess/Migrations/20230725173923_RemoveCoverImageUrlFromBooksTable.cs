using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCoverImageUrlFromBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "C# is the foundation of .NET development. New features added in C# 6 and 7 make it easier to take on big data applications, cloud-centric web development, and cross-platform software using .NET Core. Packed with deep insight from C# guru Jon Skeet, this book takes you deep into concepts and features other C# books ignore.\r\n\r\nC# in Depth, Fourth Edition is an authoritative and engaging guide that reveals the full potential of the language, including the new features of C# 6 and 7. It combines deep dives into the C# language with practical techniques for enterprise development, web applications, and systems programming. As you absorb the wisdom and techniques in this book, you’ll write better code, and become an exceptional troubleshooter and problem solver.\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverImageUrl",
                value: "https://m.media-amazon.com/images/I/411LNpmcEnL._SX260_.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "Description" },
                values: new object[] { null, "Building Web APIs with ASP.NET Core is a practical beginner’s guide to creating your first web APIs using ASP.NET Core. In it, you’ll develop an API that feeds web-based services, including websites and mobile apps, for a board games application. The book is cleverly structured to mirror a real-world development project, with each chapter introducing a new feature request. You’ll build your API with an ecosystem of ASP.NET Core tools that help simplify everything from setting up your data model to generating documentation" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverImageUrl",
                value: "https://d374oxlv7wyffd.cloudfront.net/B0977Z1DHC/f2ea5a9a/cover.jpeg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CoverImageUrl",
                value: "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableQuantity", "CategoryId", "CoverImageUrl", "Description", "DiscountedPrice", "ISBN", "ListPrice", "PublicationDate", "Title" },
                values: new object[] { 5, "Nick Trenton", 100, 1, "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg", "Overcome negative thought patterns, reduce stress, and live a worry-free life.\r\nOverthinking is the biggest cause of unhappiness. Don't get stuck in a never-ending thought loop. Stay present and keep your mind off things that don't matter, and never will.\r\nBreak free of your self-imposed mental prison.\r\nStop Overthinking is a book that understands where you’ve been through,the exhausting situation you’ve put yourself into, and how you lose your mind in the trap of anxiety and stress. Acclaimed author Nick Trenton will walk you through the obstacles with detailed and proven techniques to help you rewire your brain, control your thoughts, and change your mental habits.What’s more, the book will provide you scientific approaches to completely change the way you think and feel about yourself by ending the vicious thought patterns.\r\nStop agonizing over the past and trying to predict the future.\r\nNick Trenton grew up in rural Illinois and is quite literally a farm boy. His best friend growing up was his trusty companion Leonard the dachshund. RIP Leonard. Eventually, he made it off the farm and obtained a BS in Economics, followed by an MA in Behavioral Psychology.\r\nPowerful ways to stop ruminating and dwelling on negative thoughts.\r\n-How to be aware of your negative spiral triggers-Identify and recognize your inner anxieties-How to keep the focus on relaxation and action-Proven methods to overcome stress attacks-Learn to declutter your mind and find focus\r\nUnleash your unlimited potential and start living.\r\nNo more self-deprecating talk. No more sleepless nights with racing thoughts. Free your mind from overthinking and achieve more, feel better, and unleash your potential. Finally be able to live in the present moment.\r\nLive a stress-free life and conquer overthinking", null, "9798715048394", 10.64m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road to Surrender: Three Men and the Countdown to the End of World War II" });
        }
    }
}
