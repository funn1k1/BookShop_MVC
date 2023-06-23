using BookShopWeb_Razor.Data;
using BookShopWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShopWeb_Razor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _dbContext.Categories.Add(Category);
            _dbContext.SaveChanges();
            TempData["Success"] = "Category added successfully";
            return RedirectToPage("Index");
        }
    }
}
