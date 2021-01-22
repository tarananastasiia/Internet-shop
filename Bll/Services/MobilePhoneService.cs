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

namespace Bll.Services
{
    public class MobilePhoneService : IMobilePhoneService
    {
        IMobilePhoneRepositories _mobilePhoneRepositories;

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

        public PageDTO GetFilteringByPrice([FromQuery]PageRequestDto pageRequestDto)
        {
            Func<MobilePhones, bool> predicate = x=> x.Price >= pageRequestDto.MinPrice && x.Price <= pageRequestDto.MaxPrice;

            var pageDto = new PageDTO();
            pageDto.Phones = _mobilePhoneRepositories.GetModelsFilteringByPrice(predicate).
                Skip((pageRequestDto.PageNumber - 1) * pageRequestDto.PageSize)
                           .Take(pageRequestDto.PageSize).ToList();
            pageDto.PhonesCount = _mobilePhoneRepositories.GetModelsFilteringByPrice(predicate).Count();
            return pageDto;
        }
    }
}
