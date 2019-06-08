using System;
using System.Collections.Generic;

namespace Tmss_Back_end.Data.Repository.Interface.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Guid Add(T entity);

        T Update(T entity);

        void Remove(Guid id);

        T Get(Guid id);

        List<T> All();
        void CreateDatabase();
    }
}