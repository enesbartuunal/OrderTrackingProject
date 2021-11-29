using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _01_AppCore.Entities;

namespace _01_AppCore.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
