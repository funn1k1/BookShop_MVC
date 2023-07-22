using BookShopWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace BookShopWeb.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        string? GetRoleId(string userId);

        IdentityRole? GetRole(string? roleId);

        void Update(ApplicationUser user);
    }
}
