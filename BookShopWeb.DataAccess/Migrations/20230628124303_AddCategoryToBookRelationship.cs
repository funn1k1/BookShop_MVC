using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShopWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToBookRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "PublicationDate" },
                values: new object[] { 2, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ListPrice", "PublicationDate" },
                values: new object[] { 2, 60.49m, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableQuantity", "CategoryId", "CoverImageUrl", "Description", "DiscountedPrice", "ISBN", "ListPrice", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 4, "Evan Thomas", 100, 3, "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg", "A riveting, immersive account of the agonizing decision to use nuclear weapons against Japan—a crucial turning point in World War II and geopolitical history—with you-are-there immediacy by the New York Times bestselling author of Ike's Bluff and Sea of Thunder.\r\n\r\n“A terrifying, heartbreaking account of three men under unimaginable pressure . . . I challenge you not to read this book in a single sitting.”—Nathaniel Philbrick, author of In the Heart of the Sea and Travels with George\r\n\r\nAt 9:20 a.m. on the morning of May 30, General Groves receives a message to report to the office of the secretary of war “at once.” Stimson is waiting for him. He wants to know: has Groves selected the targets yet?\r\n\r\nSo begins this suspenseful, impeccably researched history that draws on new access to diaries to tell the story of three men who were intimately involved with America’s decision to drop the atomic bomb—and Japan’s decision to surrender. They are Henry Stimson, the American Secretary of War, who had overall responsibility for decisions about the atom bomb; Gen. Carl “Tooey” Spaatz, head of strategic bombing in the Pacific, who supervised the planes that dropped the bombs; and Japanese Foreign Minister Shigenori Togo, the only one in Emperor Hirohito’s Supreme War Council who believed even before the bombs were dropped that Japan should surrender.\r\n\r\nHenry Stimson had served in the administrations of five presidents, but as the U.S. nuclear program progressed, he found himself tasked with the unimaginable decision of determining whether to deploy the bomb. The new president, Harry S. Truman, thus far a peripheral figure in the momentous decision, accepted Stimson’s recommendation to drop the bomb. Army Air Force Commander Gen. Spaatz ordered the planes to take off. Like Stimson, Spaatz agonized over the command even as he recognized it would end the war. After the bombs were dropped, Foreign Minister Togo was finally able to convince the emperor to surrender.\r\n\r\nTo bring these critical events to vivid life, bestselling author Evan Thomas draws on the diaries of Stimson, Togo and Spaatz, contemplating the immense weight of their historic decision. In Road to Surrender, an immersive, surprising, moving account, Thomas lays out the behind-the-scenes thoughts, feelings, motivations, and decision-making of three people who changed history", null, "9780399589256", 20m, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road to Surrender: Three Men and the Countdown to the End of World War II" },
                    { 5, "Nick Trenton", 100, 1, "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg", "Overcome negative thought patterns, reduce stress, and live a worry-free life.\r\nOverthinking is the biggest cause of unhappiness. Don't get stuck in a never-ending thought loop. Stay present and keep your mind off things that don't matter, and never will.\r\nBreak free of your self-imposed mental prison.\r\nStop Overthinking is a book that understands where you’ve been through,the exhausting situation you’ve put yourself into, and how you lose your mind in the trap of anxiety and stress. Acclaimed author Nick Trenton will walk you through the obstacles with detailed and proven techniques to help you rewire your brain, control your thoughts, and change your mental habits.What’s more, the book will provide you scientific approaches to completely change the way you think and feel about yourself by ending the vicious thought patterns.\r\nStop agonizing over the past and trying to predict the future.\r\nNick Trenton grew up in rural Illinois and is quite literally a farm boy. His best friend growing up was his trusty companion Leonard the dachshund. RIP Leonard. Eventually, he made it off the farm and obtained a BS in Economics, followed by an MA in Behavioral Psychology.\r\nPowerful ways to stop ruminating and dwelling on negative thoughts.\r\n-How to be aware of your negative spiral triggers-Identify and recognize your inner anxieties-How to keep the focus on relaxation and action-Proven methods to overcome stress attacks-Learn to declutter your mind and find focus\r\nUnleash your unlimited potential and start living.\r\nNo more self-deprecating talk. No more sleepless nights with racing thoughts. Free your mind from overthinking and achieve more, feel better, and unleash your potential. Finally be able to live in the present moment.\r\nLive a stress-free life and conquer overthinking", null, "9798715048394", 10.64m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road to Surrender: Three Men and the Countdown to the End of World War II" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ListPrice", "PublicationDate" },
                values: new object[] { 50.99m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
