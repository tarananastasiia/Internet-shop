using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bll.Services
{
    public class BaseSortingService<TEntity> where TEntity : BaseProduct
    {
        Dictionary<string, Expression<Func<TEntity, object>>> dict = new Dictionary<string, Expression<Func<TEntity, object>>>();
        public BaseSortingService()
        {
            dict.Add("category", x => x.Category);
            dict.Add("name", x => x.Name);
            dict.Add("price", x => x.Price);
            dict.Add("colour", x => x.Colour);
        }
        public Expression<Func<TEntity, object>> GetSorter(string columnName)
        {
            Expression<Func<TEntity, object>> sorter = dict[columnName];
            return sorter;
        }
    }
}
