namespace BookShopWeb.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCart> Items { get; set; }

        public decimal OverallPrice { get; set; }
    }
}
