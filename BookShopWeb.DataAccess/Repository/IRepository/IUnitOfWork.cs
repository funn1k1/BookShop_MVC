namespace BookShopWeb.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }

        IBookRepository Books { get; }

        ICompanyRepository Companies { get; }

        IApplicationUserRepository Users { get; }

        IShoppingCartRepository ShoppingCart { get; }

        IOrderHeaderRepository OrderHeaders { get; }

        IOrderDetailRepository OrderDetails { get; }

        void Save();
    }
}
