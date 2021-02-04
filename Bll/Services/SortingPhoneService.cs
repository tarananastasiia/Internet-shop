using Bll.Services.Contracts;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bll.Services
{
    public class SortingPhoneService
    {
        Dictionary<string, Expression<Func<MobilePhones, object>>> dict = new Dictionary<string, Expression<Func<MobilePhones, object>>>();
        public SortingPhoneService()
        {
            dict.Add("Name", x => x.Name);
            dict.Add("Price", x => x.Price);
            dict.Add("Quantity", x => x.Quantity);
            dict.Add("Id", x => x.Id);
        }
        public Expression<Func<MobilePhones, object>> GetSorter(string columnName)
        {
            Expression<Func<MobilePhones, object>> sorter = dict[columnName];
            return sorter;
        }
    }
}
