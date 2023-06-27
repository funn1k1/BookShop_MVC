using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);
    }
}
