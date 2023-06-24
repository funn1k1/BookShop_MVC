using BookShopWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new Category[]
            {
                new Category() { Id = 1, Name = "Business", DisplayOrder = 1 },
                new Category() { Id = 2, Name = "Technologies", DisplayOrder = 2 },
                new Category() { Id = 3, Name = "History", DisplayOrder = 3 }
            };
            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
