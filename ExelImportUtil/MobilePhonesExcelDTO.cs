using ExelImportUtil.Parcers.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExelImportUtil
{
    public class MobilePhonesExcelDTO
    {
      
        public int Id { get; set; } 

        [Column(1, ParserType = typeof(StringParser))]
        public string Category { get; set; }
        [Column(2, ParserType = typeof(IntParser))]
        public int VendorCode { get; set; }
        [Column(3, ParserType = typeof(StringParser))]
        public string ModificationArticle { get; set; }
        [Column(4, ParserType = typeof(StringParser))]
        public string Name { get; set; }
       // [Column(5, ParserType = typeof(StringParser))]
        public double Price { get; set; }
        [Column(6, ParserType = typeof(IntParser))]
        public int Quantity { get; set; }
        [Column(7, ParserType = typeof(StringParser))]
        public string Description { get; set; }
        [Column(8, ParserType = typeof(StringParser))]
        public string Manufacturer { get; set; }
        [Column(9, ParserType = typeof(StringParser))]
        public string Photo { get; set; }
       // [Column(10, ParserType = typeof(StringParser))]
        public List<string> LinkToPhoto { get; set; }
        [Column(11, ParserType = typeof(StringParser))]
        public string Colour { get; set; }

        public string testNonAttribute { get; set; }

    }
}
