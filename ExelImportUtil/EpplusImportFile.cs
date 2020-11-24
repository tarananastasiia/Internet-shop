using ExelImportUtil.Parcers;
using OfficeOpenXml;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Drawing;
using DocumentFormat.OpenXml.Drawing;
using OfficeOpenXml.Style;

namespace ExelImportUtil
{
    public class EpplusImportFile
    {
        //public List<MobilePhonesExcelDTO> GetMobilePhones(byte[] bin)
        //{
        //    List<MobilePhonesExcelDTO> mobilePhones = new List<MobilePhonesExcelDTO>(); ;
        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (MemoryStream stream = new MemoryStream(bin))
        //    using (ExcelPackage excelPackage = new ExcelPackage(stream))
        //    {
        //        foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
        //        {
        //            for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
        //            {
        //                MobilePhonesExcelDTO dto = new MobilePhonesExcelDTO();

        //                dto.Category = worksheet.Cells[i, 1].Value?.ToString();
        //                dto.VendorCode = Int32.Parse(worksheet.Cells[i, 2].Value?.ToString());
        //                dto.ModificationArticle = worksheet.Cells[i, 3].Value?.ToString();
        //                dto.Name = worksheet.Cells[i, 4].Value?.ToString();
        //                dto.Price = Double.Parse(worksheet.Cells[i, 5].Value?.ToString());
        //                dto.Quantity = Int32.Parse(worksheet.Cells[i, 6].Value?.ToString());
        //                dto.Description = worksheet.Cells[i, 7].Value?.ToString();
        //                dto.Manufacturer = worksheet.Cells[i, 8].Value?.ToString();
        //                dto.Photo = worksheet.Cells[i, 9].Value?.ToString();
        //                dto.LinkToPhoto = worksheet.Cells[i, 10].Value?.ToString().Split(" ").ToList();
        //                dto.Colour = worksheet.Cells[i, 11].Value?.ToString();
        //                mobilePhones.Add(dto);
        //            }
        //        }
        //    }
        //    return mobilePhones;
        //}

        public List<T> GetEntityExel<T>(byte[] bin) where T : new()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var properties = typeof(T).GetProperties();
            var propsWithAttribute = properties.Where(p => p.IsDefined(typeof(ColumnNameAttribute)));

            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[typeof(T).GetCustomAttribute<SheetAttribute>().Sheet];
                Dictionary<int, PropertyInfo> dictColumnAndProps = propsWithAttribute.ToDictionary(p =>
                {
                    var columnNumber = NumberColumn(p.GetCustomAttribute<ColumnNameAttribute>().Column, worksheet);
                    return columnNumber;
                }, p => p);

                List<T> mobilePhones = new List<T>();

                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    T dto = new T();

                    foreach (var keyValue in dictColumnAndProps)
                    {
                        var a = keyValue.Value.GetCustomAttribute<ColumnNameAttribute>().Validator.IsValid(worksheet.Cells[i, keyValue.Key].Value?.ToString());
                        if (a == true)
                        {
                            var parcer = keyValue.Value.GetCustomAttribute<ColumnNameAttribute>().Parser;
                            var value = parcer.Parce(worksheet.Cells[i, keyValue.Key].Value?.ToString());
                            keyValue.Value.SetValue(dto, value);
                        }
                        else
                        {
                            worksheet.Cells[i, keyValue.Key].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, keyValue.Key].Style.Fill.BackgroundColor.SetColor(Color.Red);
                            FileInfo fi = new FileInfo("C:/Users/vladyslav.haliaha/Desktop/Catalog/Mobile.xlsx");
                            excelPackage.SaveAs(fi);
                        }



                    }

                    mobilePhones.Add(dto);
                }

                return mobilePhones;
            }
        }
        public int NumberColumn(string name, ExcelWorksheet worksheet)
        {
            for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
            {
                if (worksheet.Cells[1, j].Value.ToString() == name)
                {
                    return j;
                }
            }
            throw new Exception("не знайдена колонка");

        }
    }
}
