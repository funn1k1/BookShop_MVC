using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWeb.Models.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }

        [Display(Name = "Images")]
        public IEnumerable<IFormFile?>? Files { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
