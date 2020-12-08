using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.ViewModels
{
    public class PageDTO
    {
        public List<MobilePhones> Phones { get; set; }
        public int PhonesCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public PageDTO()
        {
            Phones = new List<MobilePhones>();
        }
    }
}
