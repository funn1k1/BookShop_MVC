using System.Security.Claims;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using BookShopWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

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

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult UpdateDetails(OrderViewModel orderVM)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Details), orderVM);
            }

            var orderHeader = _unitOfWork.OrderHeaders.Get(o => o.Id == orderVM.OrderHeader.Id);
            if (orderHeader is null)
            {
                return NotFound();
            }

            orderHeader.FullName = orderVM.OrderHeader.FullName;
            orderHeader.Address = orderVM.OrderHeader.Address;
            orderHeader.City = orderVM.OrderHeader.City;
            orderHeader.Country = orderVM.OrderHeader.Country;
            orderHeader.PostalCode = orderVM.OrderHeader.PostalCode;
            orderHeader.PhoneNumber = orderVM.OrderHeader.PhoneNumber;
            orderHeader.TrackingNumber = orderVM.OrderHeader.TrackingNumber;
            orderHeader.Carrier = orderVM.OrderHeader.Carrier;
            orderHeader.ShippingDate = orderVM.OrderHeader.ShippingDate;

            _unitOfWork.OrderHeaders.Update(orderHeader);
            _unitOfWork.Save();

            TempData["Success"] = "Order Details successfully updated";

            return RedirectToAction(nameof(Details), new { id = orderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult ProcessOrder(OrderViewModel orderVM)
        {
            var orderHeader = _unitOfWork.OrderHeaders.Get(o => o.Id == orderVM.OrderHeader.Id);
            if (orderHeader is null)
            {
                return NotFound();
            }

            orderHeader.OrderStatus = OrderStatuses.Processing;
            _unitOfWork.OrderHeaders.Update(orderHeader);
            _unitOfWork.Save();
            TempData["Success"] = "Order Status has been successfully changed to \"Processing\"";

            return RedirectToAction(nameof(Details), new { id = orderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult ShipOrder(OrderViewModel orderVM)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Details), orderVM);
            }

            var orderHeader = _unitOfWork.OrderHeaders.Get(o => o.Id == orderVM.OrderHeader.Id);
            if (orderHeader is null)
            {
                return NotFound();
            }

            orderHeader.Carrier = orderVM.OrderHeader.Carrier;
            orderHeader.TrackingNumber = orderVM.OrderHeader.TrackingNumber;
            orderHeader.OrderStatus = OrderStatuses.Shipped;
            orderHeader.ShippingDate = DateTime.Now;

            _unitOfWork.OrderHeaders.Update(orderHeader);
            _unitOfWork.Save();
            TempData["Success"] = "Order Status has been successfully changed to \"Shipped\"";

            return RedirectToAction(nameof(Details), new { id = orderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult CancelOrder(OrderViewModel orderVM)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Details), orderVM);
            }

            var orderHeader = _unitOfWork.OrderHeaders.Get(o => o.Id == orderVM.OrderHeader.Id);
            if (orderHeader is null)
            {
                return NotFound();
            }

            var options = new RefundCreateOptions
            {
                Reason = RefundReasons.RequestedByCustomer,
                PaymentIntent = orderHeader.PaymentIntentId
            };

            var service = new RefundService();
            var refund = service.Create(options);

            _unitOfWork.OrderHeaders.UpdateStatuses(orderHeader.Id, OrderStatuses.Cancelled, PaymentStatuses.Refunded);
            _unitOfWork.Save();
            TempData["Success"] = "Order Status has been successfully changed to \"Cancelled\"";

            return RedirectToAction(nameof(Details), new { id = orderHeader.Id });
        }

        [HttpGet]
        public IActionResult GetAll(string? status = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeaders;

            if (User.IsInRole(Roles.Admin))
            {
                orderHeaders = _unitOfWork.OrderHeaders
                    .GetAll(navigationProperties: "ApplicationUser");
            }
            else
            {
                orderHeaders = _unitOfWork.OrderHeaders
                    .GetAll(o => o.ApplicationUserId == userId, navigationProperties: "ApplicationUser");
            }

            switch (status)
            {
                case PaymentStatuses.Pending:
                    orderHeaders = orderHeaders.Where(o => o.PaymentStatus == PaymentStatuses.Pending);
                    break;
                case PaymentStatuses.Approved:
                    orderHeaders = orderHeaders.Where(o => o.PaymentStatus == PaymentStatuses.Approved);
                    break;
                case PaymentStatuses.Delayed:
                    orderHeaders = orderHeaders.Where(o => o.PaymentStatus == PaymentStatuses.Delayed);
                    break;
                case PaymentStatuses.Refunded:
                    orderHeaders = orderHeaders.Where(o => o.PaymentStatus == PaymentStatuses.Refunded);
                    break;
                case PaymentStatuses.Rejected:
                    orderHeaders = orderHeaders.Where(o => o.PaymentStatus == PaymentStatuses.Rejected);
                    break;
            }

            return Json(new { data = orderHeaders });
        }
    }
}
