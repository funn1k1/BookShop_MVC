using System.Security.Claims;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using BookShopWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var orderHeader = _unitOfWork.OrderHeaders.Get(o => o.Id == id, "ApplicationUser");
            if (orderHeader is null)
            {
                return NotFound();
            }

            var orderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderHeaderId == orderHeader.Id, "Book,Book.Category");

            var orderVM = new OrderViewModel
            {
                OrderHeader = orderHeader,
                OrderDetails = orderDetails
            };
            return View(orderVM);
        }

        [HttpGet]
        public IActionResult GetAll(string? status = null)
        {
            IEnumerable<OrderHeader> orderHeaders;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            switch (status)
            {
                case PaymentStatuses.Pending:
                    orderHeaders = _unitOfWork.OrderHeaders
                        .GetAll(o => o.ApplicationUserId == userId && o.PaymentStatus == status, navigationProperties: "ApplicationUser");
                    break;
                case PaymentStatuses.Approved:
                    orderHeaders = _unitOfWork.OrderHeaders
                        .GetAll(o => o.ApplicationUserId == userId && o.PaymentStatus == status, navigationProperties: "ApplicationUser");
                    break;
                case PaymentStatuses.Delayed:
                    orderHeaders = _unitOfWork.OrderHeaders
                        .GetAll(o => o.ApplicationUserId == userId && o.PaymentStatus == status, navigationProperties: "ApplicationUser");
                    break;
                case PaymentStatuses.Rejected:
                    orderHeaders = _unitOfWork.OrderHeaders
                        .GetAll(o => o.ApplicationUserId == userId && o.PaymentStatus == status, navigationProperties: "ApplicationUser");
                    break;
                default:
                    orderHeaders = _unitOfWork.OrderHeaders
                        .GetAll(o => o.ApplicationUserId == userId, navigationProperties: "ApplicationUser");
                    break;
            }
            return Json(new { data = orderHeaders });
        }
    }
}
