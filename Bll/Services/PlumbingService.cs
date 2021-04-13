using Bll.Services.Contracts;
using Dal.Models;
using Dal.Repositories.Contracts;
using DTOs.ViewModels;
using ExelImportUtil;
using Microsoft.AspNetCore.Http;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bll.Services
{
    public class PlumbingService: BaseSortingService<Plumbing>, IPlumbingService
    {
        IPlumbingRepositories _plumbingRepositories;
        public PlumbingService(IPlumbingRepositories plumbingRepositories)
        {
            _plumbingRepositories = plumbingRepositories;
        }
        public void UploadFile(byte[] bin, IFormFile file)
        {
            EpplusImportFile epplusImportFile = new EpplusImportFile();
            var plumbingDtos = epplusImportFile.GetEntityExel<PlumbingExcelDTO>(bin, file);

            var plumbings = plumbingDtos.Select(p => new Plumbing
            {
                Category = p.Category,
                VendorCode = p.VendorCode,
                Colour = p.Colour,
                Name = p.Name,
                Description = p.Description,
                Manufacturer = p.Manufacturer,
                ModificationArticle = p.ModificationArticle,
                Price = p.Price,
                Quantity = p.Quantity,
                Id = p.Id
            }).ToList();
            _plumbingRepositories.Save(plumbings);
        }

        public PageDTO GetFiltering(PageRequestDto pageRequestDto)
        {
            Expression<Func<Plumbing, bool>> predicate = x => true;
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

            var pageDto = new PageDTO();
            pageDto.Plumbings = _plumbingRepositories.GetModelsFiltering(predicate, pageRequestDto.PageNumber,
                pageRequestDto.PageSize, sorter, pageRequestDto.AscendingOrDescending)
                .ToList();
            pageDto.Count = _plumbingRepositories.Count(predicate);
            return pageDto;
        }
    }
}
