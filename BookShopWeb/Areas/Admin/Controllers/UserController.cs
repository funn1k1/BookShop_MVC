using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Block(string id)
        {
            var user = _unitOfWork.Users.Get(b => b.Id == id);
            if (user is null)
            {
                return Json(new { success = false, message = "No user found" });
            }

            if (user.LockoutEnd is null)
            {
                user.LockoutEnd = DateTimeOffset.Now.AddYears(1);
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
                return Json(new { success = true, message = $"The user has been blocked" });
            }

            return Json(new { success = false, message = "The user is already blocked" });
        }

        [HttpPut]
        public IActionResult Unblock(string id)
        {
            var user = _unitOfWork.Users.Get(b => b.Id == id);
            if (user is null)
            {
                return Json(new { success = false, message = "No user found" });
            }

            if (user.LockoutEnd is not null)
            {
                user.LockoutEnd = null;
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
                return Json(new { success = true, message = $"The user has been unblocked" });
            }

            return Json(new { success = false, message = "The user is already unblocked" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                var roleId = _unitOfWork.Users.GetRoleId(user.Id);
                var role = _unitOfWork.Users.GetRole(roleId);
                user.Role = role?.Name ?? "No role";
            }
            return Json(new { data = users });
        }

        public IActionResult RoleManagment(string id)
        {
            var user = _unitOfWork.Users.Get(u => u.Id == id);
            if (user is null)
            {
                return NotFound();
            }

            var roleId = _unitOfWork.Users.GetRoleId(user.Id);
            if (roleId is not null)
            {
                var userRole = _unitOfWork.Users.GetRole(roleId);
                user.Role = userRole.Name;
            }

            var userVM = new UserViewModel
            {
                User = user,
                Roles = _unitOfWork.Users.GetRoles().Select(u => new SelectListItem
                {
                    Value = u.Name,
                    Text = u.Name
                }),
            };
            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> RoleManagment(UserViewModel userVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByIdAsync(userVM.User.Id);
            if (user is null)
            {
                return NotFound();
            }

            user.FullName = userVM.User.FullName;

            var roleId = _unitOfWork.Users.GetRoleId(userVM.User.Id);
            var roleName = _unitOfWork.Users.GetRole(roleId)?.Name;
            if (roleName is not null && roleName != userVM.User.Role)
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
                await _userManager.AddToRoleAsync(user, userVM.User.Role);

            }

            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
