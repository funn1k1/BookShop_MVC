using BookShopWeb.Models;

namespace BookShopWeb.DataAccess.Repository.IRepository
{
    public interface IBookImageRepository : IRepository<BookImage>
    {
        void Update(BookImage bookImage);
    }
}
