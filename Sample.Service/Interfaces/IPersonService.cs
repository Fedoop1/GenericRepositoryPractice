using Sample.Model;
using Sample.Service.Interfaces;

namespace Sample.Repository.Interfaces
{
    public interface IPersonService : IEntityService<Person>
    {
        public Person GetById(long id);
    }
}
