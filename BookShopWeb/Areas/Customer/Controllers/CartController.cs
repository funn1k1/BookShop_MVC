using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using BookShopWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string userId)
        {
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId, "Book,Book.Category");
            if (!shoppingCarts.Any())
            {
                return NotFound();
            }

            foreach (var shoppingCart in shoppingCarts)
            {
                var bookPrice = shoppingCart.Book.ListPrice;
                shoppingCart.TotalListPrice = bookPrice * shoppingCart.Quantity;
            }

            var shoppingCartVM = new ShoppingCartViewModel
            {
                Items = shoppingCarts,
                OrderHeader = new OrderHeader
                {
                    OrderTotal = shoppingCarts.Sum(c => c.TotalListPrice),
                    ApplicationUserId = userId
                }
            };

            return View(shoppingCartVM);
        }

        public IActionResult UpdateBookQuantity(int cartId, int quantity)
        {
            var book = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            if (book is null)
            {
                return NotFound();
            }

            book.Quantity = quantity;
            _unitOfWork.ShoppingCart.Update(book);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index), new { userId = book.ApplicationUserId });
        }

        public IActionResult RemoveBook(int cartId)
        {
            var book = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            if (book is null)
            {
                return NotFound();
            }

            _unitOfWork.ShoppingCart.Remove(book);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index), new { userId = book.ApplicationUserId });
        }

        public IActionResult Checkout(string userId)
        {
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId, "Book,Book.Category");
            if (!shoppingCarts.Any())
            {
                return NotFound();
            }

            foreach (var shoppingCart in shoppingCarts)
            {
                var bookPrice = shoppingCart.Book.ListPrice;
                shoppingCart.TotalListPrice = bookPrice * shoppingCart.Quantity;
            }

            var user = _unitOfWork.Users.Get(u => u.Id == userId);

            var shoppingCartVM = new ShoppingCartViewModel
            {
                Items = shoppingCarts,
                OrderHeader = new OrderHeader
                {
                    ApplicationUserId = user?.Id,
                    FullName = user.FullName,
                    Country = user.Country,
                    City = user.City,
                    PostalCode = user.PostalCode,
                    Address = user.Address,
                    OrderTotal = shoppingCarts.Sum(c => c.TotalListPrice)
                }
            };

            return View(shoppingCartVM);
        }

        [HttpPost]
        public IActionResult Checkout(ShoppingCartViewModel shoppingCartVM)
        {
            shoppingCartVM.Items = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == shoppingCartVM.OrderHeader.ApplicationUserId, "Book,Book.Category");
            if (!ModelState.IsValid)
            {
                return View(shoppingCartVM);
            }

            var orderHeader = new OrderHeader
            {
                FullName = shoppingCartVM.OrderHeader.FullName,
                Address = shoppingCartVM.OrderHeader.Address,
                Country = shoppingCartVM.OrderHeader.Country,
                City = shoppingCartVM.OrderHeader.City,
                PostalCode = shoppingCartVM.OrderHeader.PostalCode,
                PhoneNumber = shoppingCartVM.OrderHeader.PhoneNumber,
                OrderDate = DateTime.Now,
                ApplicationUserId = shoppingCartVM.OrderHeader.ApplicationUserId,
                OrderTotal = shoppingCartVM.Items.Sum(c => c.TotalListPrice),
                OrderStatus = OrderStatuses.Pending,
                PaymentStatus = PaymentStatuses.Pending,
            };

            _unitOfWork.OrderHeaders.Add(orderHeader);
            _unitOfWork.Save();

            var orderDetails = new List<OrderDetail>();
            foreach (var shoppingCart in shoppingCartVM.Items)
            {
                var orderDetail = new OrderDetail
                {
                    OrderHeaderId = orderHeader.Id,
                    BookId = shoppingCart.BookId,
                    TotalPrice = shoppingCart.Book.ListPrice * shoppingCart.Quantity,
                    Quantity = shoppingCart.Quantity,
                };
                orderDetails.Add(orderDetail);
            }

            _unitOfWork.OrderDetails.AddRange(orderDetails);
            _unitOfWork.Save();

            return RedirectToAction(nameof(OrderConfirmation), new { orderId = orderHeader.Id });
        }

        public IActionResult OrderConfirmation(int orderId)
        {
            var orderHeader = _unitOfWork.OrderHeaders.Get(o => o.Id == orderId, "ApplicationUser");
            if (orderHeader is null)
            {
                return NotFound();
            }

            var orderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderHeaderId == orderHeader.Id, "Book,Book.Category");
            var orderVM = new OrderConfirmationViewModel
            {
                OrderHeader = orderHeader,
                OrderDetails = new List<OrderDetail>()
            };
            foreach (var orderDetail in orderDetails)
            {
                orderVM.OrderDetails.Add(orderDetail);
            }

            return View(orderVM);
        }
    }
}
