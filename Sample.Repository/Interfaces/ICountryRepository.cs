using Sample.Model;

namespace Sample.Repository.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        public Country GetById(long id);
    }
}
