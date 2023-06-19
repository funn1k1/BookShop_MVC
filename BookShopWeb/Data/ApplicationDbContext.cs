using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    }
}
