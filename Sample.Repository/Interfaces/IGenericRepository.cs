using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sample.Model;

namespace Sample.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
