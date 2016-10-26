using LVSA.Base.Domain.Interfaces.Repository;
using LVSA.Base.Domain.Interfaces.Services;
using LVSA.Financial.Domain.Interfaces.Repository;
using LVSA.Financial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LVSA.Financial.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> All()
        {
            return _repository.All();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }        

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
