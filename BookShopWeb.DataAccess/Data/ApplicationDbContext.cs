using BookShopWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    PublicationDate = new DateTime(2023, 6, 30),
                    CoverImageUrl = null,
                    AvailableQuantity = 100,
                },
                new Book()
                {
                    Id = 3,
                    Title = "ASP.NET Core in Action, Second Edition",
                    Author = "Andrew Lock",
                    Description = "ASP.NET Core in Action, Second Edition is a comprehensive guide to creating web applications with ASP.NET Core 5.0. Go from basic HTTP concepts to advanced framework customization. Illustrations and annotated code make learning visual and easy. Master logins, dependency injection, security, and more. This updated edition covers the latest features, including Razor Pages and the new hosting paradigm",
                    ISBN = "9781617298301",
                    ListPrice = 50.99M,
                    DiscountedPrice = null,
                    PublicationDate = new DateTime(2023, 6, 30),
                    CoverImageUrl = "https://d374oxlv7wyffd.cloudfront.net/B0977Z1DHC/f2ea5a9a/cover.jpeg",
                    AvailableQuantity = 100,
                },
            };
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
