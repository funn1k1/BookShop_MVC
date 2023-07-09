using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShopWeb.Models.ViewModels
{
    public class BookDescriptionViewModel
    {
        [ValidateNever]
        public Book Book { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
