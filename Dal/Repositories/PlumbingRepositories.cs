using Dal.Models;
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
    public class PlumbingRepositories : IPlumbingRepositories
    {

        ApplicationContext _context;
        public PlumbingRepositories(ApplicationContext context)
        {
            _context = context;
        }

        public void AddFile(IList<Plumbing> plumbings)
        {
          _context.BulkInsert(plumbings);
        }

        public IEnumerable<Plumbing> GetModelsFiltering(Expression<Func<Plumbing, bool>> predicate, int pageNumber, int pageSize,
            Expression<Func<Plumbing, object>> ordering, bool ascendingOrDescending)
        {
            IQueryable<Plumbing> plumbings = null;
            if (ascendingOrDescending == true)
            {
                plumbings =
                       _context.Plumbings
                       .Where(predicate)
                       .OrderBy(ordering)
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize);

            }
            else
            {
                plumbings =
                      _context.Plumbings
                      .Where(predicate)
                      .OrderByDescending(ordering)
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize);
            }
            return plumbings.ToList();
        }

        public int CountPlumbings(Expression<Func<Plumbing, bool>> predicate)
        {
            var count = _context
                   .Plumbings
                   .Count(predicate);
            return count;
        }
    }
}
