using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ExelImportUtil;
using SiteMy.Models;
using Bll.Services.Contracts;

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

        public List<MobilePhones> GetMobilePhone()
        {
            var phones = _context.MobilePhones.Take(20).ToList();

            return phones;
        }
    }
}
