using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
        }

        public void Update(ShoppingCart shoppingCart)
        {
            var existingShoppingCart = _db.ShoppingCart.Find(shoppingCart.Id);
            if (existingShoppingCart != null)
            {
                _db.Entry(existingShoppingCart).CurrentValues.SetValues(shoppingCart);
            }
        }
    }
}
