using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.ViewModels
{
    public class PageRequestDto
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
