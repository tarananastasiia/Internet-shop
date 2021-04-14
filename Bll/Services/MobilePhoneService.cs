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
        public MobilePhoneService(IEpplusImportFile epplusImport, IBaseCrudRepository<MobilePhones> baseCrudRepository) : base(baseCrudRepository)
        {
            _epplusImport = epplusImport;
            _baseCrudRepository= baseCrudRepository;
        }

        public void UploadFile(byte[] bin, IFormFile file)
        {
            var phonesDtos = _epplusImport.GetEntityExel<MobilePhonesExcelDTO>(bin, file);

            var phones = phonesDtos.Select(p => new MobilePhones
            {
                Category = p.Category,
                VendorCode = p.VendorCode,
                Colour = p.Colour,
                Name = p.Name,
                Description = p.Description,
                LinkToPhotos = p.LinkToPhoto.Select(link => new LinkToPhoto() { Link = link }).ToList(),
                Manufacturer = p.Manufacturer,
                ModificationArticle = p.ModificationArticle,
                Photo = p.Photo,
                Price = p.Price,
                Quantity = p.Quantity,
                Id = p.Id
            }).ToList();

            _baseCrudRepository.Save(phones);
        }

        public PageDTO<MobilePhones> GetFiltering(PageRequestDto pageRequestDto)
        {
           return BaseGetFiltering(pageRequestDto);
        }
    }
}
