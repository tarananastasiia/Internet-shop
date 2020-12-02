﻿using ExelImportUtil.Parcers;
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

namespace ExelImportUtil
{
    public class EpplusImportFile
    {
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
                        ErrorsMessages errors = new ErrorsMessages();
                        keyValue.Value.GetCustomAttribute<ColumnNameAttribute>().Validator.Validation(worksheet.Cells[i, keyValue.Key].Value?.ToString(), errors);
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
                            FileInfo file = new FileInfo("C:/Users/vladyslav.haliaha/Desktop/Catalog/Mobile.xlsx");
                            excelPackage.SaveAs(file);
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