using System;
using System.Collections.Generic;
using Sample.Model;
using Sample.Repository;
using Sample.Repository.Interfaces;
using Sample.Service.Interfaces;

namespace Sample.Service
{
    public abstract class EntityService<T> : IEntityService<T>
        where T : BaseEntity
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<T> repository;

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository) =>
            (this.repository, this.unitOfWork) = (
                repository ?? throw new ArgumentNullException(nameof(repository), "Repository can't be null"),
                unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "Unit of work can't be null"));

        public void Create(T entity)
        {
            this.repository.Add(entity ?? throw new ArgumentNullException(nameof(entity), "Entity can't be null"));
            this.unitOfWork.Commit();
        }
            

        public void Update(T entity)
        {
            this.repository.Update(entity ?? throw new ArgumentNullException(nameof(entity), "Entity can't be null"));
            this.unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            this.repository.Delete(entity);
            this.unitOfWork.Commit();
        }

        public IEnumerable<T> GetAll() => this.repository.GetAll();
    }
}
