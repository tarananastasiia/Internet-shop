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

        public PageDTO GetFiltering([FromQuery]PageRequestDto pageRequestDto)
        {
            Func<MobilePhones, bool> predicate = x=> x.Price >= pageRequestDto.MinPrice && x.Price <= pageRequestDto.MaxPrice;

            var pageDto = new PageDTO();
            if (pageRequestDto.PageNumber != 0)
                pageDto.Phones = _mobilePhoneRepositories.GetModelsFiltering(predicate, pageRequestDto.PageNumber,pageRequestDto.PageSize).ToList();

                pageDto.PhonesCount = _mobilePhoneRepositories.CountMobiles(pageDto.Phones);
            return pageDto;
        }

        public PageDTO GetSorting([FromQuery]SorterDto sorterDto)
        {
            var pageDto = new PageDTO();
            if (sorterDto.PageNumber != 0)
                pageDto.Phones = _mobilePhoneRepositories.GetSorting(sorterDto.ColumnNumberBySorting,sorterDto.Sort).
                   Skip((sorterDto.PageNumber - 1) * sorterDto.PageSize)
                              .Take(sorterDto.PageSize).ToList();
            pageDto.PhonesCount = pageDto.Phones.Count();
            return pageDto;

        }
    }
}
