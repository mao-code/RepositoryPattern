using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternPractice.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
	{
        //the context here is generic, so it has nothing to do with my application
        //so you can DI some specific contexts
        //protected because the specific repository can use it
        protected readonly DbContext Context;

		public Repository(DbContext context)
		{
            Context = context;
		}

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        //don't return IQueryable!!
        //Repository should encapsulate the query
        //so on the Service or Controller won't get too much pressure
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}

