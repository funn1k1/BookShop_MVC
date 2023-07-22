using BookShopWeb.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}
