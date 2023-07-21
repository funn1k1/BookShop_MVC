using BookShopWeb.DataAccess.Data;
using BookShopWeb.Models;
using BookShopWeb.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            // Apply migrations if they have not been applied
            await ApplyMigrations();

            // SeedRoles
            await SeedRoles();

            // Create Admin user, if it does not exist
            var admin = new ApplicationUser
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                FullName = "Admin Admin",
                Country = "USA",
                City = "New York",
                PostalCode = 23483,
                Address = "848 Hamilton Road",
            };
            await SeedUsers(admin, "Admin12345*");
        }

        public async Task ApplyMigrations()
        {
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                await _db.Database.MigrateAsync();
            }
        }

        public async Task SeedRoles()
        {
            var roleNames = new string[] { Roles.Admin, Roles.User, Roles.Manager };
            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    var role = new IdentityRole(roleName);
                    await _roleManager.CreateAsync(role);
                }
            }
        }

        public async Task SeedUsers(ApplicationUser user, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser is null)
            {
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Admin);
                }
            }
        }
    }
}
