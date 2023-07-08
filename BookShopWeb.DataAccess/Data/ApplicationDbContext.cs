using BookShopWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categories = new Category[]
            {
                new Category() { Id = 1, Name = "Business", DisplayOrder = 1 },
                new Category() { Id = 2, Name = "Technologies", DisplayOrder = 2 },
                new Category() { Id = 3, Name = "History", DisplayOrder = 3 }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            var books = new Book[]
            {
                new Book()
                {
                    Id = 1,
                    Title = "Building Web APIs with ASP.NET Core",
                    Author = "Valerio De Sanctis",
                    Description = "Building Web APIs with ASP.NET Core is a practical beginner’s guide to creating your first web APIs using ASP.NET Core. In it, you’ll develop an API that feeds web-based services, including websites and mobile apps, for a board games application. The book is cleverly structured to mirror a real-world development project, with each chapter introducing a new feature request. You’ll build your API with an ecosystem of ASP.NET Core tools that help simplify everything from setting up your data model to generating documentation",
                    ISBN = "9781633439481",
                    ListPrice = 47.50M,
                    DiscountedPrice = null,
                    PublicationDate = new DateTime(2023, 6, 30),
                    CoverImageUrl = "https://m.media-amazon.com/images/I/411LNpmcEnL._SX260_.jpg",
                    AvailableQuantity = 100,
                    CategoryId = 2
                },
                new Book()
                {
                    Id = 2,
                    Title = "C# in Depth",
                    Author = "Jon Skeet",
                    Description = "Building Web APIs with ASP.NET Core is a practical beginner’s guide to creating your first web APIs using ASP.NET Core. In it, you’ll develop an API that feeds web-based services, including websites and mobile apps, for a board games application. The book is cleverly structured to mirror a real-world development project, with each chapter introducing a new feature request. You’ll build your API with an ecosystem of ASP.NET Core tools that help simplify everything from setting up your data model to generating documentation",
                    ISBN = "9781617294532",
                    ListPrice = 38.99M,
                    DiscountedPrice = null,
                    PublicationDate = new DateTime(2023, 3, 17),
                    CoverImageUrl = null,
                    AvailableQuantity = 100,
                    CategoryId = 2
                },
                new Book()
                {
                    Id = 3,
                    Title = "ASP.NET Core in Action, Second Edition",
                    Author = "Andrew Lock",
                    Description = "ASP.NET Core in Action, Second Edition is a comprehensive guide to creating web applications with ASP.NET Core 5.0. Go from basic HTTP concepts to advanced framework customization. Illustrations and annotated code make learning visual and easy. Master logins, dependency injection, security, and more. This updated edition covers the latest features, including Razor Pages and the new hosting paradigm",
                    ISBN = "9781617298301",
                    ListPrice = 60.49M,
                    DiscountedPrice = null,
                    PublicationDate = new DateTime(2023, 3, 18),
                    CoverImageUrl = "https://d374oxlv7wyffd.cloudfront.net/B0977Z1DHC/f2ea5a9a/cover.jpeg",
                    AvailableQuantity = 100,
                    CategoryId = 2,
                },
                new Book()
                {
                    Id = 4,
                    Title = "Road to Surrender: Three Men and the Countdown to the End of World War II",
                    Author = "Evan Thomas",
                    Description = "A riveting, immersive account of the agonizing decision to use nuclear weapons against Japan—a crucial turning point in World War II and geopolitical history—with you-are-there immediacy by the New York Times bestselling author of Ike's Bluff and Sea of Thunder.\r\n\r\n“A terrifying, heartbreaking account of three men under unimaginable pressure . . . I challenge you not to read this book in a single sitting.”—Nathaniel Philbrick, author of In the Heart of the Sea and Travels with George\r\n\r\nAt 9:20 a.m. on the morning of May 30, General Groves receives a message to report to the office of the secretary of war “at once.” Stimson is waiting for him. He wants to know: has Groves selected the targets yet?\r\n\r\nSo begins this suspenseful, impeccably researched history that draws on new access to diaries to tell the story of three men who were intimately involved with America’s decision to drop the atomic bomb—and Japan’s decision to surrender. They are Henry Stimson, the American Secretary of War, who had overall responsibility for decisions about the atom bomb; Gen. Carl “Tooey” Spaatz, head of strategic bombing in the Pacific, who supervised the planes that dropped the bombs; and Japanese Foreign Minister Shigenori Togo, the only one in Emperor Hirohito’s Supreme War Council who believed even before the bombs were dropped that Japan should surrender.\r\n\r\nHenry Stimson had served in the administrations of five presidents, but as the U.S. nuclear program progressed, he found himself tasked with the unimaginable decision of determining whether to deploy the bomb. The new president, Harry S. Truman, thus far a peripheral figure in the momentous decision, accepted Stimson’s recommendation to drop the bomb. Army Air Force Commander Gen. Spaatz ordered the planes to take off. Like Stimson, Spaatz agonized over the command even as he recognized it would end the war. After the bombs were dropped, Foreign Minister Togo was finally able to convince the emperor to surrender.\r\n\r\nTo bring these critical events to vivid life, bestselling author Evan Thomas draws on the diaries of Stimson, Togo and Spaatz, contemplating the immense weight of their historic decision. In Road to Surrender, an immersive, surprising, moving account, Thomas lays out the behind-the-scenes thoughts, feelings, motivations, and decision-making of three people who changed history",
                    ISBN = "9780399589256",
                    ListPrice = 20M,
                    DiscountedPrice = null,
                    PublicationDate = new DateTime(2023, 6, 16),
                    CoverImageUrl = "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg",
                    AvailableQuantity = 100,
                    CategoryId = 3,
                },
                new Book()
                {
                    Id = 5,
                    Title = "Road to Surrender: Three Men and the Countdown to the End of World War II",
                    Author = "Nick Trenton",
                    Description = "Overcome negative thought patterns, reduce stress, and live a worry-free life.\r\nOverthinking is the biggest cause of unhappiness. Don't get stuck in a never-ending thought loop. Stay present and keep your mind off things that don't matter, and never will.\r\nBreak free of your self-imposed mental prison.\r\nStop Overthinking is a book that understands where you’ve been through,the exhausting situation you’ve put yourself into, and how you lose your mind in the trap of anxiety and stress. Acclaimed author Nick Trenton will walk you through the obstacles with detailed and proven techniques to help you rewire your brain, control your thoughts, and change your mental habits.What’s more, the book will provide you scientific approaches to completely change the way you think and feel about yourself by ending the vicious thought patterns.\r\nStop agonizing over the past and trying to predict the future.\r\nNick Trenton grew up in rural Illinois and is quite literally a farm boy. His best friend growing up was his trusty companion Leonard the dachshund. RIP Leonard. Eventually, he made it off the farm and obtained a BS in Economics, followed by an MA in Behavioral Psychology.\r\nPowerful ways to stop ruminating and dwelling on negative thoughts.\r\n-How to be aware of your negative spiral triggers-Identify and recognize your inner anxieties-How to keep the focus on relaxation and action-Proven methods to overcome stress attacks-Learn to declutter your mind and find focus\r\nUnleash your unlimited potential and start living.\r\nNo more self-deprecating talk. No more sleepless nights with racing thoughts. Free your mind from overthinking and achieve more, feel better, and unleash your potential. Finally be able to live in the present moment.\r\nLive a stress-free life and conquer overthinking",
                    ISBN = "9798715048394",
                    ListPrice = 10.64M,
                    DiscountedPrice = null,
                    PublicationDate = new DateTime(2021, 3, 1),
                    CoverImageUrl = "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg",
                    AvailableQuantity = 100,
                    CategoryId = 1,
                },
            };
            modelBuilder.Entity<Book>().HasData(books);

            var companies = new Company[]
            {
                new Company()
                {
                    Id = 1,
                    Name = "Microsoft",
                    Country = "USA",
                    City = "Redmond",
                    Address = "WA 98052",
                },
                new Company()
                {
                    Id = 2,
                    Name = "Google",
                    Country = "USA",
                    City = "Mountain View",
                    Address = "1600 Amphitheatre Parkway"
                },
                new Company()
                {
                    Id = 3,
                    Name = "IBM",
                    Country = "USA",
                    City = "Armonk",
                    Address = "1 New Orchard Rd"
                },
                new Company()
                {
                    Id = 4,
                    Name = "Oracle",
                    Country = "USA",
                    City = "Austin",
                    Address = "2300 Cloud Way"
                },
            };
            modelBuilder.Entity<Company>().HasData(companies);
        }
    }
}
