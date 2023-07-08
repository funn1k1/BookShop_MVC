namespace BookShopWeb.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }

        IBookRepository Books { get; }

        ICompanyRepository Companies { get; }

        void Save();
    }
}
