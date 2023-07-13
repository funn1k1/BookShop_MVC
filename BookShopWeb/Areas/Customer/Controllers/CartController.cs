using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
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
    }
}
