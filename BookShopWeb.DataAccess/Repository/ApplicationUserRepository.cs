using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace BookShopWeb.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IdentityRole? GetRole(string? roleId)
        {
            var role = _db.Roles.Find(roleId);
            return role;
        }

        public string? GetRoleId(string userId)
        {
            var roleId = _db.UserRoles.FirstOrDefault(ur => ur.UserId == userId)?.RoleId;
            return roleId;
        }

        public void Update(ApplicationUser user)
        {
            var existingUser = _db.Users.Find(user.Id);
            if (existingUser != null)
            {
                _db.Entry(existingUser).CurrentValues.SetValues(user);
            }
        }
    }
}
