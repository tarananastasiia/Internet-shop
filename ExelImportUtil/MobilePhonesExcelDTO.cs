using ExelImportUtil.Parcers.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExelImportUtil
{
    [Sheet("Products")]
    public class MobilePhonesExcelDTO
    {
        public int Id { get; set; } 

        [Column("Категория", ParserType = typeof(StringParser))]
        public string Category { get; set; }
        [Column("Артикул", ParserType = typeof(IntParser))]
        public int VendorCode { get; set; }
        [Column("Артикул модификации", ParserType = typeof(StringParser))]
        public string ModificationArticle { get; set; }
        [Column("Имя товара", ParserType = typeof(StringParser))]
        public string Name { get; set; }
        [Column("Цена", ParserType = typeof(DoubleParser))]
        public double Price { get; set; }
        [Column("Количество", ParserType = typeof(IntParser))]
        public int Quantity { get; set; }
        [Column("Описание", ParserType = typeof(StringParser))]
        public string Description { get; set; }
        [Column("Производитель", ParserType = typeof(StringParser))]
        public string Manufacturer { get; set; }
        [Column("Фото", ParserType = typeof(StringParser))]
        public string Photo { get; set; }
        [Column("Ссылки на фото", ParserType = typeof(ListParser))]
        public List<string> LinkToPhoto { get; set; }
        [Column("Цвет", ParserType = typeof(StringParser))]
        public string Colour { get; set; }

        public string testNonAttribute { get; set; }

    }
}
