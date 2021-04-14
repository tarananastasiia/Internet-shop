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
        public int? MinPrice { get; set; }

        [Range(0, Int32.MaxValue)]
        public int? MaxPrice { get; set; }

        [Range(1, Int32.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 200)]
        public int PageSize { get; set; } = 20;
        public string SortingColumnName { get; set; }
        public bool AscendingOrDescending { get; set; }
    }
}
