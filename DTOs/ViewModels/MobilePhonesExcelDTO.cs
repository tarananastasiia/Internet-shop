using ExelImportUtil.Parcers.Impl;
using ExelImportUtil.Validation.Param;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Reflection;

namespace ExelImportUtil
{
    [Sheet("Products")]
    public class MobilePhonesExcelDTO
    {
        public int Id { get; set; }

        [ColumnName("Категория", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNullValidator))]
        public string Category { get; set; }
        [ColumnName("Артикул", ParserType = typeof(IntParser), ValidType = typeof(IntValidator))]
        public int VendorCode { get; set; }

        [ColumnName("Артикул модификации", ParserType = typeof(StringParser), ValidType = typeof(StringValidator) )]
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

        [ColumnName("Фото", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNullValidator))]
        public string Photo { get; set; }

        [ColumnName("Ссылки на фото", ParserType = typeof(ListParser), ValidType = typeof(ListValidator))]
        public List<string> LinkToPhoto { get; set; }

        [ColumnName("Цвет", ParserType = typeof(StringParser), ValidType = typeof(StringValidator))]
        public string Colour { get; set; }

        public string testNonAttribute { get; set; }

    }
}
