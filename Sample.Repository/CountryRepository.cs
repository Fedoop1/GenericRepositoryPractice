using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sample.Model;
using Sample.Repository.Interfaces;

namespace Sample.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context) : base(context)
        {
        }

        public Country GetById(long id) => this.Set.SingleOrDefault(x => x.Id == id);
    }
}
