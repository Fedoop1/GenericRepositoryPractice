using Sample.Model;

namespace Sample.Repository.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(long id);
    }
}
