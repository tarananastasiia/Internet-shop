using Dal.Repositories.Contracts;
using DocumentFormat.OpenXml.Bibliography;
using EFCore.BulkExtensions;
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
    public class MobilePhoneRepositories : BaseCrudRepository<MobilePhones>, IMobilePhoneRepositories
    {
        public MobilePhoneRepositories(ApplicationContext context) : base(context) { }


        public void Save(IList<MobilePhones> phones)
        {
            _context.BulkInsert(phones);
        }

    }
}
