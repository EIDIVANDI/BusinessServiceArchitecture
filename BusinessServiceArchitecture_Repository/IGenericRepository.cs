using BusinessServiceArchitecture_Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessServiceArchitecture_Repository
{

    public interface IGenericRepository
    {
    }

    public interface IGenericRepository<TEntity> : IGenericRepository
        where TEntity : class
    {
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        long Count(Expression<Func<TEntity, bool>> predicate);

        long Count();
    }

}