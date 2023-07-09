using System.Linq.Expressions;

namespace BookShopWeb.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? navigationProperties = null, bool isTracked = false);

        T? Get(Expression<Func<T, bool>> predicate, string? navigationProperties = null, bool isTracked = false);

        void Add(T? entity);

        void Remove(T? entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
