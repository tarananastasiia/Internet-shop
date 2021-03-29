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
            dict.Add("category", x => x.Category);
            dict.Add("name", x => x.Name);
            dict.Add("price", x => x.Price);
            dict.Add("colour", x => x.Colour);
        }
        public Expression<Func<MobilePhones, object>> GetSorter(string columnName)
        {
            Expression<Func<MobilePhones, object>> sorter = dict[columnName];
            return sorter;
        }
    }
}
