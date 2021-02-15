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

namespace Bll.Services
{
    public class MobilePhoneService : IMobilePhoneService
    {
        IMobilePhoneRepositories _mobilePhoneRepositories;
        public MobilePhoneService(IMobilePhoneRepositories mobilePhoneRepositories)
        {
            _mobilePhoneRepositories = mobilePhoneRepositories;
        }

        public void UploadFile(byte[] bin)
        {
            EpplusImportFile epplusImportFile = new EpplusImportFile();
            var phonesDtos = epplusImportFile.GetEntityExel<MobilePhonesExcelDTO>(bin);

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
            _mobilePhoneRepositories.AddFile(phones);

        }

        public PageDTO GetFiltering(PageRequestDto pageRequestDto)
        {
            Expression<Func<MobilePhones, bool>> predicate = x => x.Price >= pageRequestDto.MinPrice && x.Price <= pageRequestDto.MaxPrice;
            SortingPhoneService sortingPhoneService = new SortingPhoneService();

            var sorter = sortingPhoneService.GetSorter(pageRequestDto.SortingColumnName);

            var pageDto = new PageDTO();
            pageDto.Phones = _mobilePhoneRepositories.GetModelsFiltering(predicate, pageRequestDto.PageNumber,
                pageRequestDto.PageSize, sorter, pageRequestDto.AscendingOrDescending)
                .ToList();
            pageDto.PhonesCount = _mobilePhoneRepositories.CountMobiles(predicate);
            return pageDto;
        }

    }
}
