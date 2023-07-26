using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository
{
    public class BookImageRepository : Repository<BookImage>, IBookImageRepository
    {
        public BookImageRepository(ApplicationDbContext db) : base(db) { }

        public void Update(BookImage bookImage)
        {
            var existingBookImage = _db.BookImages.Find(bookImage.Id);
            if (existingBookImage != null)
            {
                _db.Entry(existingBookImage).CurrentValues.SetValues(bookImage);
            }
        }
    }
}
