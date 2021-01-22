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

namespace Bll.Services
{
    public class MobilePhoneService : IMobilePhoneService
    {
        ApplicationContext _context;
        public MobilePhoneService(ApplicationContext context)
        {
            _context = context;
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

            _context.MobilePhones.AddRange(phones);
            _context.SaveChanges();
        }

        public PageDTO GetFilteringByPrice([FromQuery]PageRequestDto pageRequestDto)
        {
            var pageDto = new PageDTO();
            var models = _context.MobilePhones.Where(x => x.Price >= pageRequestDto.MinPrice && x.Price <= pageRequestDto.MaxPrice).
                Skip((pageRequestDto.PageNumber - 1) * pageRequestDto.PageSize)
                           .Take(pageRequestDto.PageSize).ToList();
            pageDto.Phones = models;
            pageDto.PhonesCount = _context.MobilePhones.Where(x=>x.Price >= pageRequestDto.MinPrice && x.Price <= pageRequestDto.MaxPrice).Count();
            return pageDto;
        }
    }
}
