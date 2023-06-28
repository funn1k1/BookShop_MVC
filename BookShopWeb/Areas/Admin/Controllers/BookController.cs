using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Upsert(int? id)
        {
            var bookVM = new BookViewModel
            {
                CategoryList = _unitOfWork.Categories.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
            };

            if (id is null)
            {
                bookVM.Book = new Book();
                return View(bookVM);
            }
            else
            {
                var book = _unitOfWork.Books.Get(c => c.Id == id);
                if (book is null)
                {
                    return NotFound();
                }

                bookVM.Book = book;
            }

            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Upsert(BookViewModel bookVM, IFormFile file)
        {
            if (bookVM.Book.Id != 0)
            {
                _unitOfWork.Books.Update(bookVM.Book);
                _unitOfWork.Save();
                TempData["Success"] = "Book edited successfully";
            }
            else
            {
                _unitOfWork.Books.Add(bookVM.Book);
                _unitOfWork.Save();
                TempData["Success"] = "Book created successfully";
            }

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
