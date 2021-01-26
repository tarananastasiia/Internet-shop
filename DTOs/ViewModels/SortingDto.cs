using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.ViewModels
{
    public class SortingDto
    {
        public int ColumnNumberBySorting { get; set; }
        public bool Sort { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
