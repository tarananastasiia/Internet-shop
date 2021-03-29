using Dal.Repositories.Contracts;
using DocumentFormat.OpenXml.Bibliography;
using ExelImportUtil;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Dal.Repositories
{
    public class MobilePhoneRepositories : IMobilePhoneRepositories
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

        public IEnumerable<MobilePhones> GetModelsFiltering(Expression<Func<MobilePhones, bool>> predicate, int pageNumber, int pageSize,
            Expression<Func<MobilePhones, object>> ordering, bool ascendingOrDescending)
        {
            IQueryable<MobilePhones> mobiles = null;
            if (ascendingOrDescending == true)
            {
                mobiles =
                       _context.MobilePhones
                       .Where(predicate)
                       .OrderBy(ordering)
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize);

            }
            else
            {
                mobiles =
                      _context.MobilePhones
                      .Where(predicate)
                      .OrderByDescending(ordering)
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize);
            }
            return mobiles.ToList();
        }

        public int CountMobiles(Expression<Func<MobilePhones, bool>> predicate)
        {
            var count = _context
                   .MobilePhones
                   .Count(predicate);

            return count;
        }
    }
}
