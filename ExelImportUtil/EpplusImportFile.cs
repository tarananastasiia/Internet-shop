using ExelImportUtil.Parcers;
using OfficeOpenXml;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExelImportUtil
{
    public class EpplusImportFile
    {
        public List<MobilePhonesExcelDTO> GetMobilePhones(byte[] bin)
        {
            List<MobilePhonesExcelDTO> mobilePhones = new List<MobilePhonesExcelDTO>(); ;
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                    {
                        MobilePhonesExcelDTO dto = new MobilePhonesExcelDTO();

                        dto.Category = worksheet.Cells[i, 1].Value?.ToString();
                        dto.VendorCode = Int32.Parse(worksheet.Cells[i, 2].Value?.ToString());
                        dto.ModificationArticle = worksheet.Cells[i, 3].Value?.ToString();
                        dto.Name = worksheet.Cells[i, 4].Value?.ToString();
                        dto.Price = Double.Parse(worksheet.Cells[i, 5].Value?.ToString());
                        dto.Quantity = Int32.Parse(worksheet.Cells[i, 6].Value?.ToString());
                        dto.Description = worksheet.Cells[i, 7].Value?.ToString();
                        dto.Manufacturer = worksheet.Cells[i, 8].Value?.ToString();
                        dto.Photo = worksheet.Cells[i, 9].Value?.ToString();
                        dto.LinkToPhoto = worksheet.Cells[i, 10].Value?.ToString().Split(" ").ToList();
                        dto.Colour = worksheet.Cells[i, 11].Value?.ToString();
                        mobilePhones.Add(dto);
                    }
                }
            }
            return mobilePhones;
        }

        public List<T> GetEntityExel<T>(byte[] bin) where T : new()
        {

            var properties = typeof(T).GetProperties();
            var propsWithAttribute = properties.Where(p => p.IsDefined(typeof(ColumnAttribute)));


            Dictionary<int, PropertyInfo> dictColumnAndProps = propsWithAttribute.ToDictionary(p => p.GetCustomAttribute<ColumnAttribute>().Column, p => p);

            List<T> mobilePhones = new List<T>();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                    {
                        T dto = new T();

                        foreach (var keyValue in dictColumnAndProps)
                        {
                            var parcer = keyValue.Value.GetCustomAttribute<ColumnAttribute>().Parser;
                            var value = parcer.Parce(worksheet.Cells[i, keyValue.Key].Value?.ToString());
                            keyValue.Value.SetValue(dto, value);
                        }

                        mobilePhones.Add(dto);

                        //dto.Category = worksheet.Cells[i, 1].Value?.ToString();
                        //dto.VendorCode = Int32.Parse(worksheet.Cells[i, 2].Value?.ToString());
                        //dto.ModificationArticle = worksheet.Cells[i, 3].Value?.ToString();
                        //dto.Name = worksheet.Cells[i, 4].Value?.ToString();
                        //dto.Price = Double.Parse(worksheet.Cells[i, 5].Value?.ToString());
                        //dto.Quantity = Int32.Parse(worksheet.Cells[i, 6].Value?.ToString());
                        //dto.Description = worksheet.Cells[i, 7].Value?.ToString();
                        //dto.Manufacturer = worksheet.Cells[i, 8].Value?.ToString();
                        //dto.Photo = worksheet.Cells[i, 9].Value?.ToString();
                        //dto.LinkToPhoto = worksheet.Cells[i, 10].Value?.ToString().Split(" ").ToList();
                        //dto.Colour = worksheet.Cells[i, 11].Value?.ToString();

                    }
                }
            }
            return mobilePhones;
        }
    }
}
