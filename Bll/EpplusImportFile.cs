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
    public  class EpplusImportFile : IEpplusImportFile
    {
        public List<TEntity> GetEntityExel<TEntity>(byte[] bin, IFormFile files) where TEntity : new()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var properties = typeof(TEntity).GetProperties();
            var propsWithAttribute = properties.Where(p => p.IsDefined(typeof(ColumnNameAttribute)));

            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[typeof(TEntity).GetCustomAttribute<SheetAttribute>().SheetName];
                Dictionary<int, PropertyInfo> dictColumnAndProps = propsWithAttribute.ToDictionary(p =>
                {
                    var columnNumber = NumberColumn(p.GetCustomAttribute<ColumnNameAttribute>().Column, worksheet);
                    return columnNumber;
                }, p => p);

                List<TEntity> category = new List<TEntity>();

                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    TEntity dto = new TEntity();

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
                            FileInfo file = new FileInfo("C:/Users/Anastasiia/Desktop/MyCatalog" + files.FileName);
                            excelPackage.SaveAs(file);
                        }
                    }

                    category.Add(dto);
                }

                return category;
            }
        }
        private int NumberColumn(string name, ExcelWorksheet worksheet)
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
