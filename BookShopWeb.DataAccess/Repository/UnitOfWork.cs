using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;

namespace BookShopWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository Categories { get; }

        public IBookRepository Books { get; }

        public ICompanyRepository Companies { get; }

        public IApplicationUserRepository Users { get; set; }

        public IShoppingCartRepository ShoppingCart { get; }

        public IOrderHeaderRepository OrderHeaders { get; }

        public IOrderDetailRepository OrderDetails { get; }

        public IBookImageRepository BookImages { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Categories = new CategoryRepository(db);
            Books = new BookRepository(db);
            Companies = new CompanyRepository(db);
            Users = new ApplicationUserRepository(db);
            ShoppingCart = new ShoppingCartRepository(db);
            OrderHeaders = new OrderHeaderRepository(db);
            OrderDetails = new OrderDetailRepository(db);
            BookImages = new BookImageRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
