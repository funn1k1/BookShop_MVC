using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext db) : base(db) { }

        public void Update(Book book)
        {
            var existingBook = _db.Books.Find(book.Id);
            if (existingBook != null)
            {
                _db.Entry(existingBook).CurrentValues.SetValues(book);
            }
        }
    }
}
