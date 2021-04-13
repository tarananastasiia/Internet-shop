using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dal.Repositories.Contracts
{
    public interface IPlumbingRepositories
    {
        void Save(IList<Plumbing> plumbing);
        IEnumerable<Plumbing> GetModelsFiltering(Expression<Func<Plumbing, bool>> predicate, int pageNumber, int pageSize,
             Expression<Func<Plumbing, object>> ordering, bool ascendingOrDescending);
        int Count(Expression<Func<Plumbing, bool>> predicate);
    }
}
