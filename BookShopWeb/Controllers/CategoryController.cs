using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "DisplayOrder cannot match Name");
                return View();
            }

            _categoryRepo.Add(category);
            _categoryRepo.Save();
            TempData["Success"] = "Category was created successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepo.Get(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _categoryRepo.Update(category);
            _categoryRepo.Save();
            TempData["Success"] = "Category was edited successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var category = _categoryRepo.Get(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeletePOST(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var category = _categoryRepo.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryRepo.Remove(category);
            _categoryRepo.Save();
            TempData["Success"] = "Category was deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
