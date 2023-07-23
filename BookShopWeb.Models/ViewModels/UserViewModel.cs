using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWeb.Models.ViewModels
{
    public class UserViewModel
    {
        [ValidateNever]
        public ApplicationUser User { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
