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

        public DbSet<BookImage> BookImages { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

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
                    AvailableQuantity = 100,
                    CategoryId = 2
                },
                new Book()
                {
                    Id = 2,
                    Title = "C# in Depth",
                    Author = "Jon Skeet",
                    Description = "C# is the foundation of .NET development. New features added in C# 6 and 7 make it easier to take on big data applications, cloud-centric web development, and cross-platform software using .NET Core. Packed with deep insight from C# guru Jon Skeet, this book takes you deep into concepts and features other C# books ignore.\r\n\r\nC# in Depth, Fourth Edition is an authoritative and engaging guide that reveals the full potential of the language, including the new features of C# 6 and 7. It combines deep dives into the C# language with practical techniques for enterprise development, web applications, and systems programming. As you absorb the wisdom and techniques in this book, you’ll write better code, and become an exceptional troubleshooter and problem solver.\r\n",
                    ISBN = "9781617294532",
                    ListPrice = 38.99M,
                    DiscountedPrice = null,
                    PublicationDate = new DateTime(2023, 3, 17),
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
                    AvailableQuantity = 100,
                    CategoryId = 3,
                },
            };
            modelBuilder.Entity<Book>().HasData(books);

            var bookImages = new List<BookImage>
            {
                new()
                {
                    Id = 1,
                    BookId = 1,
                    CoverImageUrl = "https://m.media-amazon.com/images/I/411LNpmcEnL._SX260_.jpg"
                },
                new()
                {
                    Id = 2,
                    BookId = 2,
                    CoverImageUrl = "https://m.media-amazon.com/images/I/41iLDz74c-L._SX397_BO1,204,203,200_.jpg"
                },
                new()
                {
                    Id = 3,
                    BookId = 3,
                    CoverImageUrl = "https://m.media-amazon.com/images/I/41ZzfjIpi0L._SX397_BO1,204,203,200_.jpg"
                },
                new()
                {
                    Id = 4,
                    BookId = 4,
                    CoverImageUrl = "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg"
                }
            };
            modelBuilder.Entity<BookImage>().HasData(bookImages);

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
