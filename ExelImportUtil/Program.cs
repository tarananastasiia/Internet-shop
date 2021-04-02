using Bll.Services;
using Dal.Repositories;
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
            byte[] bin = File.ReadAllBytes("C:/Users/vladyslav.haliaha/Desktop/Catalog/Mobile.xlsx");

            using (ApplicationContext db = new ApplicationContext(options))
            {
                //MobilePhoneRepositories mobilePhoneRepositories = new MobilePhoneRepositories(db);
                //MobilePhoneService phoneService = new MobilePhoneService(mobilePhoneRepositories);
                //phoneService.UploadFile(bin);
            }

        }
    }
}
