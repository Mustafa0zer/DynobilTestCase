using Dynobil.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.DataAccess
{
    public interface IRepository<TEntity, TEntityId> : IQuery<TEntity>
    {
        IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null);
        TEntity? Get(
          Expression<Func<TEntity, bool>> predicate,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        bool Any(Expression<Func<TEntity, bool>>? predicate = null);

        TEntity Add(TEntity entity);
        ICollection<TEntity> AddRange(ICollection<TEntity> entities);
        TEntity Update(TEntity entity);
        ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);
        TEntity Delete(TEntity entity, bool permanent = false);
        ICollection<TEntity> DeleteRange(ICollection<TEntity> entities, bool permanent = false);


    }
}
