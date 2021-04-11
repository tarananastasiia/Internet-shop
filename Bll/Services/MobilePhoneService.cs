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
    public class MobilePhoneService : IMobilePhoneService
    {
        private readonly IMobilePhoneRepositories _mobilePhoneRepositories;
        private readonly IEpplusImportFile _epplusImport;
        public MobilePhoneService(IMobilePhoneRepositories mobilePhoneRepositories, IEpplusImportFile epplusImport)
        {
            _mobilePhoneRepositories = mobilePhoneRepositories;
            _epplusImport = epplusImport;
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
            });

            _mobilePhoneRepositories.Save(phones);

        }

        public PageDTO GetFiltering(PageRequestDto pageRequestDto)
        {

            Expression<Func<MobilePhones, bool>> predicate = x => true;
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

            SortingPhoneService sortingPhoneService = new SortingPhoneService();

            var sorter = sortingPhoneService.GetSorter(pageRequestDto.SortingColumnName);

            var pageDto = new PageDTO();
            pageDto.Phones = _mobilePhoneRepositories.GetModelsFiltering(predicate, pageRequestDto.PageNumber,
                pageRequestDto.PageSize, sorter, pageRequestDto.AscendingOrDescending)
                .ToList();
            pageDto.Count = _mobilePhoneRepositories.CountMobiles(predicate);
            return pageDto;
        }

    }
}
