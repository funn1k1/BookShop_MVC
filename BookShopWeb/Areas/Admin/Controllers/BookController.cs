using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using BookShopWeb.Models.ViewModels;
using BookShopWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
                var book = _unitOfWork.Books.Get(c => c.Id == id, "Category");
                if (book is null)
                {
                    return NotFound();
                }

                bookVM.Book = book;
            }

            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Upsert(BookViewModel bookVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (bookVM.File is not null)
            {
                var imageUploadResult = UploadImage(bookVM.File);
                if (imageUploadResult.Success)
                {
                    DeleteOldImage(bookVM.Book.CoverImageUrl);
                    bookVM.Book.CoverImageUrl = imageUploadResult.ImageUrl;
                }
                else
                {
                    return BadRequest(imageUploadResult.ErrorMessage);
                }
            }

            bool isNewBook = bookVM.Book.Id == 0;

            if (isNewBook)
            {
                _unitOfWork.Books.Add(bookVM.Book);
            }
            else
            {
                _unitOfWork.Books.Update(bookVM.Book);
            }

            _unitOfWork.Save();

            TempData["Success"] = isNewBook ? "Book created successfully" : "Book edited successfully";
            return RedirectToAction(nameof(Index));
        }

        private ImageUploadResult UploadImage(IFormFile file)
        {
            if (file is null || file.Length == 0)
            {
                return new ImageUploadResult(false, errorMessage: "No image file provided");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var imageUrl = Path.Combine("images", "books", fileName);
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl);

            try
            {
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return new ImageUploadResult(true, imageUrl: $@"\{imageUrl}");
            }
            catch (Exception ex)
            {
                return new ImageUploadResult(false, errorMessage: $"Error uploading image: {ex.Message}");
            }
        }

        public void DeleteOldImage(string? imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id is null)
        //    {
        //        return NotFound();
        //    }

        //    var book = _unitOfWork.Books.Get(c => c.Id == id);
        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}

        //[HttpPost]
        //[ActionName(nameof(Delete))]
        //public IActionResult DeletePOST(int? id)
        //{
        //    if (id is null)
        //    {
        //        return NotFound();
        //    }

        //    var book = _unitOfWork.Books.Get(c => c.Id == id);
        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    DeleteOldImage(book.CoverImageUrl);

        //    _unitOfWork.Books.Remove(book);
        //    _unitOfWork.Save();
        //    TempData["Success"] = "Book deleted successfully";
        //    return RedirectToAction(nameof(Index));
        //}

        // Ajax API Call
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Books.GetAll("Category");
            return Json(new { data = products });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var book = _unitOfWork.Books.Get(b => b.Id == id);
            if (book is null)
            {
                return Json(new { success = false, message = "Error when deleting the book" });
            }

            DeleteOldImage(book.CoverImageUrl);

            _unitOfWork.Books.Remove(book);
            _unitOfWork.Save();

            return Json(new { success = true, message = $"The book has been deleted" });
        }
    }
}

class ImageUploadResult
{
    public bool Success { get; }

    public string? ImageUrl { get; }

    public string? ErrorMessage { get; }

    public ImageUploadResult(bool success, string? imageUrl = null, string? errorMessage = null)
    {
        Success = success;
        ImageUrl = imageUrl;
        ErrorMessage = errorMessage;
    }
}