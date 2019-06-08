using Lojinha.DonaMaria.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tmss_Back_end.Data.Repository.Interface.Base;
using Tmss_Back_end.Data.Service.Interface.Base;

namespace Tmss_Back_end.Data.Service.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IBaseRepository<T> _repository;

        public BaseService()
        {
            
        }
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _repository = baseRepository;
        }
        public virtual Guid Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual T Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public virtual T Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual List<T> All()
        {
            return _repository.All();
        }
        public void CreateDatabase()
        {
            _repository.CreateDatabase();
        }
    }
}