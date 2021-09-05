using System;
using Sample.Model;
using Sample.Repository.Interfaces;
using Sample.Service;

namespace Sample.Repository
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonRepository repository;
        public PersonService(IUnitOfWork unitOfWork, IPersonRepository repository) : base(unitOfWork, repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public Person GetById(long id) => this.repository.GetById(id);
    }
}
