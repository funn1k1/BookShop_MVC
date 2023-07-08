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

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Categories = new CategoryRepository(db);
            Books = new BookRepository(db);
            Companies = new CompanyRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
