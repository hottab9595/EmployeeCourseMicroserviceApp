using System;
using System.Linq;
using AuthorizationMicroservice.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Db.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public Repository(Context context)
        {
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public T Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public T Update(Guid id)
        {
            T item = Get(id);
            if (item != null)
            {
                _dbSet.Update(item);
                return _dbSet.Find(id);
            }

            return null;
        }

        public void Delete()
        {
            IQueryable<T> items = GetAll();
            if (items.Any())
            {
                _dbSet.RemoveRange(items);
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(Guid id)
        {
            T item = Get(id);
            if (item != null)
            {
                _dbSet.Remove(item);
            }
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            return query;
        }
    }
}