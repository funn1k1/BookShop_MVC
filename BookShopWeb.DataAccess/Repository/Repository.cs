﻿using System.Linq.Expressions;
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

        public void Add(T? entity) => _dbSet.Add(entity);

        public T? Get(Expression<Func<T, bool>> predicate, string? navigationProperties = null, bool isTracked = false)
        {
            IQueryable<T> query;

            if (!isTracked)
            {
                query = _dbSet.AsNoTracking();
            }
            else
            {
                query = _dbSet;
            }

            if (!string.IsNullOrEmpty(navigationProperties))
            {
                query = query.Include(navigationProperties);
            }

            return query.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(string? navigationProperties = null, bool isTracked = false)
        {
            IQueryable<T> query;

            if (!isTracked)
            {
                query = _dbSet.AsNoTracking();
            }
            else
            {
                query = _dbSet;
            }

            if (!string.IsNullOrEmpty(navigationProperties))
            {
                query = query.Include(navigationProperties);
            }

            return query.ToList();
        }

        public void Remove(T? entity) => _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    }
}
