using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.ViewModels
{
    public class PageRequestDto
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public PageDTO PageDTO { get; set; }
    }
}
