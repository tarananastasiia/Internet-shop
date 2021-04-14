using Bll.Services.Contracts;
using Dal.Models;
using Dal.Repositories.Contracts;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bll.Services
{
    public class BaseFilteringService<TEntity> where TEntity : BaseProduct
    {
        private readonly IBaseCrudRepository<TEntity> _baseCrudRepository;
        Dictionary<string, Expression<Func<TEntity, object>>> dict = new Dictionary<string, Expression<Func<TEntity, object>>>();
        public BaseFilteringService(IBaseCrudRepository<TEntity> baseCrudRepository)
        {
            _baseCrudRepository = baseCrudRepository;
            dict.Add("category", x => x.Category);
            dict.Add("name", x => x.Name);
            dict.Add("price", x => x.Price);
            dict.Add("colour", x => x.Colour);
        }
        public Expression<Func<TEntity, object>> GetSorter(string columnName)
        {
            if (columnName == null || !dict.ContainsKey(columnName) )
                return x => x.Id;

            Expression<Func<TEntity, object>> sorter = dict[columnName];
            return sorter;
        }

        public PageDTO<TEntity> BaseGetFiltering(PageRequestDto pageRequestDto)
        {
            Expression<Func<TEntity, bool>> predicate = x => true;
            if (pageRequestDto.MinPrice == null && pageRequestDto.MaxPrice != null)
            {
                predicate = x => x.Price <= pageRequestDto.MaxPrice;
            }
            if (pageRequestDto.MaxPrice == null && pageRequestDto.MinPrice != null)
            {
                predicate = x => x.Price <= pageRequestDto.MinPrice;
            }
            if (pageRequestDto.MaxPrice != null && pageRequestDto.MinPrice != null)
            {
                predicate = x => x.Price >= pageRequestDto.MinPrice && x.Price <= pageRequestDto.MaxPrice;
            }

            var sorter = GetSorter(pageRequestDto.SortingColumnName);
            PageDTO<TEntity> pageDTO = new PageDTO<TEntity>();
            pageDTO.WebEntity = _baseCrudRepository.GetModelsSorting(predicate, pageRequestDto.PageNumber,
                pageRequestDto.PageSize, sorter, pageRequestDto.AscendingOrDescending)
                .ToList();
            pageDTO.Count = _baseCrudRepository.Count(predicate);

            return pageDTO;
        }
    }
}
