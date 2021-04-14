using AutoMapper;
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
    public class PlumbingService: BaseFilteringService<Plumbing>, IBaseService<Plumbing>
    {
        private readonly IBaseCrudRepository<Plumbing> _baseCrudRepository;
        private readonly IEpplusImportFile _epplusImport;
        private readonly IMapper _mapper;
        public PlumbingService(IEpplusImportFile epplusImport, IBaseCrudRepository<Plumbing> baseCrudRepository, IMapper mapper):base(baseCrudRepository)
        {
            _epplusImport = epplusImport;
            _baseCrudRepository = baseCrudRepository;
            _mapper = mapper;
        }
        public void UploadFile(byte[] bin, IFormFile file)
        {
            var plumbingDtos = _epplusImport.GetEntityExel<PlumbingExcelDTO>(bin, file);
            var plumbings = _mapper.Map<List<Plumbing>>(plumbingDtos);
            _baseCrudRepository.Save(plumbings);
        }
        public PageDTO<Plumbing> GetFiltering(PageRequestDto pageRequestDto)
        {
            return BaseGetFiltering(pageRequestDto);
        }
    }
}
