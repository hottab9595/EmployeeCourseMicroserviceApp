using System;
using System.Linq;

namespace AuthorizationMicroservice.Db.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        T Add(T entity);
        T Update(T entity);
        T Update(Guid id);
        void Delete();
        void Delete(T entity);
        void Delete(Guid id);
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    }
}