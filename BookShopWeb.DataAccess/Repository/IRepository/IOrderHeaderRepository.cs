using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);

        void UpdateStatuses(int id, string orderStatus, string paymentStatus);

        void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId);
    }
}
