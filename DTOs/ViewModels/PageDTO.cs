using Dal.Models;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.ViewModels
{
    public class PageDTO<TEntity> where TEntity : class
    {
        public List<TEntity> WebEntity { get; set; }
        public int Count { get; set; }
        public int MaxPrice { get; set; }
        public PageDTO()
        {
            WebEntity = new List<TEntity>();
        }
    }
}
