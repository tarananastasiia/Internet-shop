using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dal.Repositories.Contracts
{
    public interface IMobilePhoneRepositories
    {
        void Save(IEnumerable<MobilePhones> phones);
        IEnumerable<MobilePhones> GetModelsFiltering(Expression<Func<MobilePhones, bool>> predicate, int pageNumber, int pageSize,
              Expression<Func<MobilePhones, object>> ordering, bool ascendingOrDescending);
        int CountMobiles(Expression<Func<MobilePhones, bool>> predicate);
    }
}
