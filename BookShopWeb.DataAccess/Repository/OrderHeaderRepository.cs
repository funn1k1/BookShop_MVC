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
    }
}
