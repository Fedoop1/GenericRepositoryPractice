using Sample.Model;
using Sample.Repository.Interfaces;
using Sample.Service.Interfaces;

namespace Sample.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICountryRepository repository;

        public CountryService(IUnitOfWork unitOfWork, ICountryRepository repository) 
            : base(unitOfWork, repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public Country GetById(long id) => this.repository.GetById(id);
    }
}
