using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.Repositories.Contracts
{
    public interface IMobilePhoneRepositories
    {
        void AddFile(IEnumerable<MobilePhones> phones);
        IEnumerable<MobilePhones> GetModelsFiltering(Func<MobilePhones, bool> predicate);
        IOrderedQueryable<MobilePhones> GetSorting(int numberColumn,bool sort);
    }
}
