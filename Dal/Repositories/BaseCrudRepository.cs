using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dal.Repositories
{
    public abstract class BaseCrudRepository<TEntity> where TEntity : class
    {
        protected ApplicationContext _context;
        public BaseCrudRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> GetModelsFiltering(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize,
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
