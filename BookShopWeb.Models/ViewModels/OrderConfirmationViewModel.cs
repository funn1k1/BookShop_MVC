namespace BookShopWeb.Models.ViewModels
{
    public class OrderConfirmationViewModel
    {
        public OrderHeader OrderHeader { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
