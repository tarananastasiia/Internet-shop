using Dal.Repositories.Contracts;
using EFCore.BulkExtensions;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dal.Repositories
{
    public class BaseCrudRepository<TEntity> : IBaseCrudRepository<TEntity>
        where TEntity : class
    {
        protected ApplicationContext _context;
        public BaseCrudRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Save(IList<TEntity> entities)
        {
            _context.BulkInsert(entities);
        }
        public IEnumerable<TEntity> GetModelsSorting(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize,
     Expression<Func<TEntity, object>> ordering, bool ascendingOrDescending)
        {

            IQueryable<TEntity> entities = null;
            if (ascendingOrDescending == true)
            {
                entities =
                       _context.Set<TEntity>()
                      .Where(predicate)
                       .OrderBy(ordering)
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize);

            }
            else
            {
                entities =
                       _context.Set<TEntity>()
                      .Where(predicate)
                      .OrderByDescending(ordering)
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize);
            }
            return entities.ToList();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            var count = _context.Set<TEntity>()
                   .Count(predicate);
            return count;
        }
  
    }
}
