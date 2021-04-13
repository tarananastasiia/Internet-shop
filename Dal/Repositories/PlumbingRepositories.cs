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
    public class PlumbingRepositories : BaseCrudRepository<Plumbing>, IPlumbingRepositories
    {

        public PlumbingRepositories(ApplicationContext context) : base(context)
        {
        }

        public void Save(IList<Plumbing> plumbings)
        {
            _context.BulkInsert(plumbings);
        }
    }
}
