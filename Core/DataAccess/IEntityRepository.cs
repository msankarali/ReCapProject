using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);

        //List<int> GetAllIds(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(List<T> entities);

        void Update(T entity);

        void Delete(T entity);
    }
}