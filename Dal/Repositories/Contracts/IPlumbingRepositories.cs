using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dal.Repositories.Contracts
{
    public interface IPlumbingRepositories
    {
        void AddFile(IList<Plumbing> plumping);
        IEnumerable<Plumbing> GetModelsFiltering(Expression<Func<Plumbing, bool>> predicate, int pageNumber, int pageSize,
             Expression<Func<Plumbing, object>> ordering, bool ascendingOrDescending);
        int CountPlumbings(Expression<Func<Plumbing, bool>> predicate);
    }
}
