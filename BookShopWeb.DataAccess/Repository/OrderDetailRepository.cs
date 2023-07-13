using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext db) : base(db) { }

        public void Update(OrderDetail orderDetail)
        {
            var existingOrder = _db.OrderDetails.Find(orderDetail.Id);
            if (existingOrder != null)
            {
                _db.Entry(existingOrder).CurrentValues.SetValues(orderDetail);
            }
        }
    }
}
