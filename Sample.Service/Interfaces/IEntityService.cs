using System.Collections.Generic;
using Sample.Model;

namespace Sample.Service.Interfaces
{
    public interface IEntityService<T> : IService 
        where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
    }
}
