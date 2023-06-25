using System.Linq.Expressions;
using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);

        public T? Get(Expression<Func<T, bool>> filter) => _dbSet.FirstOrDefault(filter);

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public void Remove(T entity) => _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    }
}
