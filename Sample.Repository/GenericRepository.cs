using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Model;

namespace Sample.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> 
        where T : BaseEntity
    {
        protected DbContext Context { get; }
        protected DbSet<T> Set { get; }

        protected GenericRepository(DbContext context)
        {
            this.Context =
                context ?? throw new ArgumentNullException(nameof(context), "Context can't be null");
            this.Set = this.Context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll() => this.Set.AsEnumerable();

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) =>
            this.Set.Where(predicate).AsEnumerable();

        public virtual T Add(T entity)
        {
            var result = this.Set.Add(entity ?? throw new ArgumentNullException(nameof(entity), "Entity can't be null"));
            return result.Entity;
        }
        public virtual T Delete(T entity)
        {
            var result = this.Set.Remove(entity ?? throw new ArgumentNullException(nameof(entity), "Entity can't be null"));
            return result.Entity;
        }

        public virtual void Update(T entity) => this.Context.Entry(entity).State = EntityState.Modified;

        public virtual void Save() => this.Context.SaveChanges();
    }
}
