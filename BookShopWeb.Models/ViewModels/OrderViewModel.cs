using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShopWeb.Models.ViewModels
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; }

        [ValidateNever]
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
