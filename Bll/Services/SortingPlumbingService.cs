using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bll.Services
{
    public class SortingPlumbingService
    {
        Dictionary<string, Expression<Func<Plumbing, object>>> dict = new Dictionary<string, Expression<Func<Plumbing, object>>>();
        public SortingPlumbingService()
        {
            dict.Add("category", x => x.Category);
            dict.Add("name", x => x.Name);
            dict.Add("price", x => x.Price);
            dict.Add("colour", x => x.Colour);
        }
        public Expression<Func<Plumbing, object>> GetSorter(string columnName)
        {
            Expression<Func<Plumbing, object>> sorter = dict[columnName];
            return sorter;
        }
    }
}
