using Dynobil.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dynobil.DataAccess.Concrete
{
    public class EfRepositoryBase<TEntity, TEntityId, TContext>: IRepository<TEntity, TEntityId>
        where TEntity : EntityBase
        where TContext :DbContext
    {
        protected readonly TContext Context;
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public ICollection<TEntity> AddRange(ICollection<TEntity> entities)
        {         
            Context.AddRange(entities);
            Context.SaveChanges();
            return entities;
        }

        public bool Any(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> queryable = Query();
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return queryable.Any();
        }

        public TEntity Delete(TEntity entity, bool permanent = false)
        {
            //SetEntityAsDeleteAsync(entity, permanent);
            Context.Remove(entity);
            Context.SaveChanges();
            return entity;
        }

        public ICollection<TEntity> DeleteRange(ICollection<TEntity> entities, bool permanent = false)
        {
            Context.RemoveRange(entities);
            Context.SaveChangesAsync();
            return entities;
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryable = Query();         
            if (include != null)
                queryable = include(queryable);           
            return queryable.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>().AsNoTracking();

            if (include != null)
            {
                query = include(query);
            }

            return query;
        }


        public IQueryable<TEntity> Query() => Context.Set<TEntity>();
        

        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public ICollection<TEntity> UpdateRange(ICollection<TEntity> entities)
        {
            Context.UpdateRange(entities);
            Context.SaveChanges();
            return entities;
        }

        
    }
}
