using BookShopWeb_Razor.Data;
using BookShopWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShopWeb_Razor.Pages.Categories
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _dbContext;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = _dbContext.Categories.Find(id.Value);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var existingCategory = _dbContext.Categories.Find(Category.Id);
            if (Category == null)
            {
                TempData["Error"] = "Failed to edit the category";
                return RedirectToPage("Index");
            }

            _dbContext.Categories.Update(existingCategory);
            _dbContext.SaveChanges();

            TempData["Success"] = "Category edited successfully";
            return RedirectToPage("Index");
        }
    }
}
