using BookShopWeb_Razor.Data;
using BookShopWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShopWeb_Razor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = _dbContext.Categories.Find(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var existingCategory = _dbContext.Categories.Find(Category.Id);
            if (existingCategory == null)
            {
                TempData["Error"] = "Failed to delete the category";
                return RedirectToPage("Index");
            }

            _dbContext.Categories.Remove(existingCategory);
            _dbContext.SaveChanges();

            TempData["Success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
