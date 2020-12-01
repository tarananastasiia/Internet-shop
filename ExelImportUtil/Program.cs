using Microsoft.EntityFrameworkCore;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExelImportUtil
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                    .UseSqlServer(@"Server=.\SQLEXPRESS;Database=Site;Trusted_Connection=True;")
                    .Options;

            EpplusImportFile epplusImportFile = new EpplusImportFile();
            byte[] bin = File.ReadAllBytes("C:/Users/vladyslav.haliaha/Desktop/Catalog/Mobile.xlsx");
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

            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.MobilePhones.AddRange(phones);
                db.SaveChanges();
            }

        }
    }
}
