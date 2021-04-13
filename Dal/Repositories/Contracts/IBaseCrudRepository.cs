using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dal.Repositories.Contracts
{
    public interface IBaseCrudRepository<TEntity> where TEntity : class
    {
        void Save(IList<TEntity> entities);
        IEnumerable<TEntity> GetModelsSorting(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize,
     Expression<Func<TEntity, object>> ordering, bool ascendingOrDescending);
        int Count(Expression<Func<TEntity, bool>> predicate);
    }
}
