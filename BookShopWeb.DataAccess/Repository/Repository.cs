using System.Linq.Expressions;
using BookShopWeb.DataAccess.Data;
using BookShopWeb.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);

        public T? Get(Expression<Func<T, bool>> filter) => _dbSet.FirstOrDefault(filter);

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public void Remove(T entity) => _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    }
}
