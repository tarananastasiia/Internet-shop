using ExelImportUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs.ViewModels
{
    public class PageRequestDto
    {
        [Range(0, Int32.MaxValue)]
        public int MinPrice { get; set; }

        [Range(0, Int32.MaxValue)]
        public int MaxPrice { get; set; }

        [Range(1, Int32.MaxValue)]
        public int PageNumber { get; set; }


        [Range(1, 200)]
        public int PageSize { get; set; }
        [Range(1, 4)]
        public string SortingColumnName { get; set; }
        public bool Sort { get; set; }
    }
}
