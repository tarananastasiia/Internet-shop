using Bll.Services;
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

            using (ApplicationContext db = new ApplicationContext(options))
            {
                MobilePhoneService phoneService = new MobilePhoneService(db);
                phoneService.UploadFile(bin);
            }

        }
    }
}
