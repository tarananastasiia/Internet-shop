using Dal.Repositories.Contracts;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.Repositories
{
    public class MobilePhoneRepositories: IMobilePhoneRepositories
    {
        ApplicationContext _context;
        public MobilePhoneRepositories(ApplicationContext context)
        {
            _context = context;
        }

        public void AddFile(IEnumerable<MobilePhones> phones)
        {
            _context.MobilePhones.AddRange(phones);
            _context.SaveChanges();
        }

        public IEnumerable<MobilePhones> GetModelsFilteringByPrice(Func<MobilePhones, bool> predicate)
        {
          var a=_context.MobilePhones.Where(predicate);
            return a;
        }
    }
}
