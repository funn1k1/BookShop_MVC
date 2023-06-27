using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var books = _unitOfWork.Books.GetAll();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _unitOfWork.Books.Add(book);
            _unitOfWork.Save();
            TempData["Success"] = "Book created successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = _unitOfWork.Books.Get(c => c.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _unitOfWork.Books.Update(book);
            _unitOfWork.Save();
            TempData["Success"] = "Book edited successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = _unitOfWork.Books.Get(c => c.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeletePOST(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = _unitOfWork.Books.Get(c => c.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            _unitOfWork.Books.Remove(book);
            _unitOfWork.Save();
            TempData["Success"] = "Book deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
