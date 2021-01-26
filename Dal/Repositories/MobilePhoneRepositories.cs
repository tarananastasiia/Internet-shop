using Dal.Repositories.Contracts;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IEnumerable<MobilePhones> GetModelsFiltering(Func<MobilePhones, bool> predicate, int pageNumber, int pageSize)
        {
            var a = _context.MobilePhones.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return a;
        }
        public int CountMobiles(IEnumerable<MobilePhones> mobilePhones)
        {
            var count = mobilePhones.Count();
            return count;
        }

        public IOrderedQueryable<MobilePhones> GetSorting(int numberColumn, bool sort)
        {
            IOrderedQueryable<MobilePhones> a=null;
            if (numberColumn==1)
            {
                if (sort == true)
                {
                    a = _context.MobilePhones.OrderBy(u => u.Category);
                }
                else
                    a = _context.MobilePhones.OrderByDescending(u => u.Category);     
            }
            if (numberColumn == 2)
            {
                if (sort == true)
                {
                    a = _context.MobilePhones.OrderBy(u => u.Name);
                }
                else
                    a = _context.MobilePhones.OrderByDescending(u => u.Name);
            }
            if (numberColumn == 3)
            {
                if (sort == true)
                {
                    a = _context.MobilePhones.OrderBy(u => u.Price);
                }
                else
                    a = _context.MobilePhones.OrderByDescending(u => u.Price);
            }
            if (numberColumn == 4)
            {
                if (sort == true)
                {
                    a = _context.MobilePhones.OrderBy(u => u.Colour);
                }
                else
                    a = _context.MobilePhones.OrderByDescending(u => u.Colour);
            }
            return a;

        }
    }
}
