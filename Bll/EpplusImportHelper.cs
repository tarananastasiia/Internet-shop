using ExelImportUtil.Parcers;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Drawing;
using DocumentFormat.OpenXml.Drawing;
using OfficeOpenXml.Style;
using ExelImportUtil.Validation;
using Microsoft.AspNetCore.Http;
using System.Collections;
using Bll.Services.Contracts;

namespace ExelImportUtil
{
    public static class EpplusImportHelper
    {
        public static List<T> GetEntityExel<T>(byte[] bin, IFormFile files) where T : new()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var properties = typeof(T).GetProperties();
            var propsWithAttribute = properties.Where(p => p.IsDefined(typeof(ColumnNameAttribute)));

            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[typeof(T).GetCustomAttribute<SheetAttribute>().SheetName];
                Dictionary<int, PropertyInfo> dictColumnAndProps = propsWithAttribute.ToDictionary(p =>
                {
                    var columnNumber = NumberColumn(p.GetCustomAttribute<ColumnNameAttribute>().Column, worksheet);
                    return columnNumber;
                }, p => p);

                List<T> category = new List<T>();

                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    T dto = new T();

                    foreach (var keyValue in dictColumnAndProps)
                    {
                        ErrorsMessages errors = new ErrorsMessages();
                        keyValue.Value.GetCustomAttribute<ColumnNameAttribute>().Validator.Validate(worksheet.Cells[i, keyValue.Key].Value?.ToString(), errors);
                        if (errors.IsNotError == true)
                        {
                            var parcer = keyValue.Value.GetCustomAttribute<ColumnNameAttribute>().Parser.Parce(worksheet.Cells[i, keyValue.Key].Value?.ToString());
                            keyValue.Value.SetValue(dto, parcer);
                        }
                        else
                        {
                            worksheet.Cells[i, keyValue.Key].AddComment(errors.Message, "Настя");
                            worksheet.Cells[i, keyValue.Key].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[i, keyValue.Key].Style.Fill.BackgroundColor.SetColor(Color.Red);
                            FileInfo file = new FileInfo("C:/Users/vladyslav.haliaha/Desktop/Catalog/" + files.FileName);
                            excelPackage.SaveAs(file);
                        }
                    }

                    category.Add(dto);
                }

                return category;
            }
        }
        private static int NumberColumn(string name, ExcelWorksheet worksheet)
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
