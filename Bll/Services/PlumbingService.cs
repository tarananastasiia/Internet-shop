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
    public class PlumbingService: BaseFilteringService<Plumbing>, IPlumbingService
    {
        private readonly IBaseCrudRepository<Plumbing> _baseCrudRepository;
        private readonly IEpplusImportFile _epplusImport;
        public PlumbingService(IEpplusImportFile epplusImport, IBaseCrudRepository<Plumbing> baseCrudRepository) : base(baseCrudRepository)
        {
            _epplusImport = epplusImport;
            _baseCrudRepository = baseCrudRepository;
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

            _baseCrudRepository.Save(plumbings);
        }

        public PageDTO<Plumbing> GetFiltering(PageRequestDto pageRequestDto)
        {
            return BaseGetFiltering(pageRequestDto);
        }
    }
}
