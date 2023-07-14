using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShopWeb.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        [ValidateNever]
        public IEnumerable<ShoppingCart> Items { get; set; }

        public OrderHeader OrderHeader { get; set; }
    }
}
