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

namespace Bll.Services
{
    public class MobilePhoneService: IMobilePhoneService
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

        public PageDTO GetMobilePhone(int pageNumber, int pageSize)
        {
            var pageDto = new PageDTO();
            pageDto.PageNumber = pageNumber;
            pageDto.PageSize = pageSize;
            pageDto.PhonesCount = _context.MobilePhones.Count();
            var models = _context.MobilePhones.Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize).ToList();
            pageDto.Phones = models;

            return pageDto;
        }

        public IQueryable<MobilePhones> GetFilteringBySort(int minPrice, int maxPrice)
        {
            var models = _context.MobilePhones.Where(x => x.Price >= minPrice && x.Price <= maxPrice);
            return models;
        }
    }
}
