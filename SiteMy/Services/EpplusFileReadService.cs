using OfficeOpenXml;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMy.Services
{
    public class EpplusFileReadService
    {
        public void GetMobilePhones(List<string> mobilePhones)
        {
            //List<string> mobilePhones = new List<string>();
            byte[] bin = File.ReadAllBytes("C:/Users/vladyslav.haliaha/Desktop/Catalog/Mobile.xlsx");
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        //loop all columns in a row
                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                        {
                            //add the cell data to the List
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                mobilePhones.Add(worksheet.Cells[i, j].Value.ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}
