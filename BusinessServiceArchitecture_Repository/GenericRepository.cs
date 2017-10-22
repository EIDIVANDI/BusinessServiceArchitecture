using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessServiceArchitecture_Repository
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        private readonly TContext DBSource;

        public GenericRepository()
        {
            DBSource = new TContext();
        }
        public void Add(TEntity entity)
        {
            DBSource.Set<TEntity>().Add(entity);
        }

        public long Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate).Count();
        }

        public long Count()
        {
            return DBSource.Set<TEntity>().Count();
        }

        public void Delete(TEntity entity)
        {
            DBSource.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Query(k => k != null);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return DBSource.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return DBSource.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            DBSource.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }

}