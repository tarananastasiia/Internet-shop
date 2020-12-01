using ExelImportUtil.Parcers.Impl;
using ExelImportUtil.Validation.Param;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExelImportUtil
{
    [Sheet("Products")]
    public class MobilePhonesExcelDTO
    {
        public int Id { get; set; }

        [ColumnName("Категория", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNull))]
        public string Category { get; set; }
        [ColumnName("Артикул", ParserType = typeof(IntParser), ValidType = typeof(IntValid))]
        public int VendorCode { get; set; }

        [ColumnName("Артикул модификации", ParserType = typeof(StringParser), ValidType = typeof(StringValid) )]
        public string ModificationArticle { get; set; }

        [ColumnName("Имя товара", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNull))]
        public string Name { get; set; }

        [ColumnName("Цена", ParserType = typeof(DoubleParser), ValidType = typeof(DoubleValid))]
        public double Price { get; set; }

        [ColumnName("Количество", ParserType = typeof(IntParser), ValidType = typeof(IntValid))]
        public int Quantity { get; set; }

        [ColumnName("Описание", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNull))]
        public string Description { get; set; }

        [ColumnName("Производитель", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNull))]
        public string Manufacturer { get; set; }

        [ColumnName("Фото", ParserType = typeof(StringParser), ValidType = typeof(StringIsNotNull))]
        public string Photo { get; set; }

        [ColumnName("Ссылки на фото", ParserType = typeof(ListParser), ValidType = typeof(ListValid))]
        public List<string> LinkToPhoto { get; set; }

        [ColumnName("Цвет", ParserType = typeof(StringParser), ValidType = typeof(StringValid))]
        public string Colour { get; set; }

        public string testNonAttribute { get; set; }

    }
}
