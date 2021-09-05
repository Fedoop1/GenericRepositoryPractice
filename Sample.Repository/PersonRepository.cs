using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sample.Model;
using Sample.Repository.Interfaces;

namespace Sample.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }

        public Person GetById(long id) => this.Set.Include(x => x.Country).SingleOrDefault(x => x.Id == id);

        public override IEnumerable<Person> GetAll() => this.Set.Include(x => x.Country).AsEnumerable();
    }
}
