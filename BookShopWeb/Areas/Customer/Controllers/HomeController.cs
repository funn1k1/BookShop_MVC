using System.Diagnostics;
using System.Security.Claims;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var books = _unitOfWork.Books.GetAll(navigationProperties: "Category");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
            {
                var cartsCount = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId).Count();
                if (cartsCount > 0)
                {
                    HttpContext.Session.SetInt32("ShoppingCart_Count", cartsCount);
                }
            }

            return View(books);
        }

        public IActionResult Details(int? id)
        {
            var book = _unitOfWork.Books.Get(b => b.Id == id, navigationProperties: "Category");
            if (book is null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var bookVM = new BookDescriptionViewModel
            {
                Book = book,
                ShoppingCart = new ShoppingCart
                {
                    Quantity = 1,
                    ApplicationUserId = userId,
                    BookId = book.Id
                }
            };
            return View(bookVM);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(BookDescriptionViewModel bookVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookVM);
            }

            var shoppingCart = _unitOfWork.ShoppingCart.Get(s =>
                s.ApplicationUserId == bookVM.ShoppingCart.ApplicationUserId &&
                s.BookId == bookVM.Book.Id);
            if (shoppingCart is null)
            {
                _unitOfWork.ShoppingCart.Add(bookVM.ShoppingCart);
                var oldCount = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == bookVM.ShoppingCart.ApplicationUserId).Count();
                HttpContext.Session.SetInt32("SessionCart_Count", oldCount + 1);
            }
            else
            {
                shoppingCart.Quantity += bookVM.ShoppingCart.Quantity;
                _unitOfWork.ShoppingCart.Update(shoppingCart);
            }

            _unitOfWork.Save();

            TempData["Success"] = "The book has been added to the cart";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}