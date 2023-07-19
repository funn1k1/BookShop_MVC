using System.Security.Claims;
using BookShopWeb.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
            {
                var count = HttpContext.Session.GetInt32("ShoppingCart_Count");
                if (count is not null)
                {
                    return View(count.GetValueOrDefault());
                }
                else
                {
                    var cartsCount = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUser.Id == userId).Count();
                    HttpContext.Session.SetInt32("ShoppingCart_Count", cartsCount);
                    return View(cartsCount);
                }
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}