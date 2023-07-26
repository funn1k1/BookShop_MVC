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
                bookVM.Book = new Book
                {
                    BookImages = new List<BookImage>()
                };
                return View(bookVM);
            }
            else
            {
                var book = _unitOfWork.Books.Get(c => c.Id == id, "Category,BookImages");
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
            bookVM.CategoryList = _unitOfWork.Categories.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            if (!ModelState.IsValid)
            {
                return View(bookVM);
            }

            if (bookVM.Files is not null)
            {
                var imageUploadResult = UploadImages(bookVM.Files, bookVM.Book);
                if (imageUploadResult.Success)
                {
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
                }
                else
                {
                    return BadRequest(imageUploadResult.ErrorMessage);
                }
            }


            return RedirectToAction(nameof(Index));
        }

        private ImageUploadResult UploadImages(IEnumerable<IFormFile> files, Book book)
        {
            if (files is null || files.Count() == 0)
            {
                return new ImageUploadResult(false, errorMessage: "No image file provided");
            }

            try
            {
                book.BookImages = new List<BookImage>();
                foreach (var file in files)
                {
                    var directoryUrl = Path.Combine("images", "books", $"book-{book.Id}");
                    var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, directoryUrl);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var imageUrl = Path.Combine(directoryUrl, fileName);
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl);

                    using (var fs = new FileStream(imagePath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }

                    var bookImage = new BookImage
                    {
                        CoverImageUrl = $@"\{imageUrl}",
                        BookId = book.Id,
                    };
                    book.BookImages.Add(bookImage);
                }

                return new ImageUploadResult(true);
            }

            catch (Exception ex)
            {
                return new ImageUploadResult(false, errorMessage: $"Error uploading images: {ex.Message}");
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
            var products = _unitOfWork.Books.GetAll(navigationProperties: "Category");
            return Json(new { data = products });
        }

        [HttpPost]
        public IActionResult DeleteImage(int id)
        {
            var bookImage = _unitOfWork.BookImages.Get(b => b.Id == id);
            if (bookImage is null)
            {
                return NotFound();
            }

            DeleteOldImage(bookImage.CoverImageUrl);

            _unitOfWork.BookImages.Remove(bookImage);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Upsert), new { id = bookImage.BookId });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var book = _unitOfWork.Books.Get(b => b.Id == id, "BookImages");
            if (book is null)
            {
                return Json(new { success = false, message = "Error when deleting the book" });
            }

            foreach (var bookImage in book.BookImages)
            {
                DeleteOldImage(bookImage.CoverImageUrl);
            }

            _unitOfWork.Books.Remove(book);
            _unitOfWork.Save();

            return Json(new { success = true, message = $"The book has been deleted" });
        }
    }
}

class ImageUploadResult
{
    public bool Success { get; }

    public string? ErrorMessage { get; }

    public ImageUploadResult(bool success, string? errorMessage = null)
    {
        Success = success;

        ErrorMessage = errorMessage;
    }
}