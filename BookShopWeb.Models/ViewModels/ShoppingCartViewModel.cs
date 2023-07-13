namespace BookShopWeb.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCart> Items { get; set; }

        public OrderHeader OrderHeader { get; set; }
    }
}
