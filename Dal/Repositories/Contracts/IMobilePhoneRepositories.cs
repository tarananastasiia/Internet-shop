using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories.Contracts
{
    public interface IMobilePhoneRepositories
    {
        void AddFile(IEnumerable<MobilePhones> phones);
        IEnumerable<MobilePhones> GetModelsFilteringByPrice(Func<MobilePhones, bool> predicate);
    }
}
