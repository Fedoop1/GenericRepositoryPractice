using Sample.Model;

namespace Sample.Service.Interfaces
{
    public interface ICountryService : IEntityService<Country>
    {
        public Country GetById(long id);
    }
}
