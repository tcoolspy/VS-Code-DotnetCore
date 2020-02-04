using System;
using System.Collections.Generic;
using dotnetPartThree.Core.Framework.Contracts.Ado;

namespace dotnetPartThree.Data.Repositories.Ado
{
    public abstract class EntityService<T> : IEntityDAL<T> where T : class
    {
        private IUnitOfWork _unitOfWork;
        private IAdoRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IAdoRepository<T> repository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            _repository = repository ?? throw new ArgumentNullException("repository");
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Insert(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}