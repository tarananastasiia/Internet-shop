using ExelImportUtil;
using ExelImportUtil.Parcers.Impl;
using ExelImportUtil.Validation.Param;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.ViewModels
{
    [Sheet("Products")]
    public class PlumbingExcelDTO
    {
        public int Id { get; set; }
        [ColumnName("Категория", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNullValidator))]
        public string Category { get; set; }
        [ColumnName("Артикул", ParserType = typeof(IntParser), ValidType = typeof(IntValidator))]
        public int VendorCode { get; set; }

        [ColumnName("Артикул модификации", ParserType = typeof(StringParser), ValidType = typeof(StringValidator))]
        public string ModificationArticle { get; set; }

        [ColumnName("Имя товара", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNullValidator))]
        public string Name { get; set; }

        [ColumnName("Цена", ParserType = typeof(DoubleParser), ValidType = typeof(DoubleValidator))]
        public double Price { get; set; }

        [ColumnName("Количество", ParserType = typeof(IntParser), ValidType = typeof(IntValidator))]
        public int Quantity { get; set; }

        [ColumnName("Описание", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNullValidator))]
        public string Description { get; set; }

        [ColumnName("Производитель", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNullValidator))]
        public string Manufacturer { get; set; }

        [ColumnName("Цвет", ParserType = typeof(StringParser), ValidType = typeof(StringValidator))]
        public string Colour { get; set; }
    }
}
