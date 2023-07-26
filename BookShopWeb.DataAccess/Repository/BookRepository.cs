using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext db) : base(db) { }

        public void Update(Book book)
        {
            var existingBook = _db.Books
                .Include(b => b.BookImages)
                .FirstOrDefault(b => b.Id == book.Id);

            if (existingBook is not null)
            {
                _db.Entry(existingBook).CurrentValues.SetValues(book);

                foreach (var image in book.BookImages)
                {
                    existingBook.BookImages.Add(new BookImage
                    {
                        CoverImageUrl = image.CoverImageUrl,
                        BookId = book.Id,
                    });
                }

                _db.Books.Update(existingBook);
            }
        }
    }
}
