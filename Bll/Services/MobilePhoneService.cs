using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ExelImportUtil;
using SiteMy.Models;
using Bll.Services.Contracts;
using DTOs.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dal.Repositories.Contracts;
using DocumentFormat.OpenXml.Bibliography;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.Collections;
using Dal.Repositories;

namespace Bll.Services
{
    public class MobilePhoneService : BaseFilteringService<MobilePhones>, IBaseService<MobilePhones>
    {
        private readonly IBaseCrudRepository<MobilePhones> _baseCrudRepository;
        private readonly IEpplusImportFile _epplusImport;

        private readonly IMapper _mapper;

        public MobilePhoneService(IEpplusImportFile epplusImport, IBaseCrudRepository<MobilePhones> baseCrudRepository, IMapper mapper) : base(baseCrudRepository)
        {
            _epplusImport = epplusImport;
            _baseCrudRepository = baseCrudRepository;
            _mapper = mapper;
        }

        public void UploadFile(byte[] bin, IFormFile file)
        {
            var phonesDtos = _epplusImport.GetEntityExel<MobilePhonesExcelDTO>(bin, file);
            var phones = _mapper.Map<List<MobilePhones>>(phonesDtos);
            _baseCrudRepository.Save(phones);
        }

        public PageDTO<MobilePhones> GetFiltering(PageRequestDto pageRequestDto)
        {
            return BaseGetFiltering(pageRequestDto);
        }
    }
}
