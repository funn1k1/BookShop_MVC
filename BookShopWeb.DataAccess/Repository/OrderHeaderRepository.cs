using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(ApplicationDbContext db) : base(db) { }

        public void Update(OrderHeader orderHeader)
        {
            var existingOrder = _db.OrderHeaders.Find(orderHeader.Id);
            if (existingOrder != null)
            {
                _db.Entry(existingOrder).CurrentValues.SetValues(orderHeader);
            }
        }

        public void UpdateStatuses(int id, string orderStatus, string paymentStatus)
        {
            var existingOrder = _db.OrderHeaders.Find(id);
            if (existingOrder == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(orderStatus))
            {
                existingOrder.OrderStatus = orderStatus;
            }

            if (!string.IsNullOrEmpty(paymentStatus))
            {
                existingOrder.PaymentStatus = paymentStatus;
            }

        }

        public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
        {
            var existingOrder = _db.OrderHeaders.Find(id);
            if (existingOrder == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(sessionId))
            {
                existingOrder.SessionId = sessionId;
            }

            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                existingOrder.PaymentIntentId = paymentIntentId;
                existingOrder.PaymentDate = DateTime.Now;
            }
        }
    }
}
