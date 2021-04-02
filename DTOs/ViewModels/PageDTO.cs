using Dal.Models;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.ViewModels
{
    public class PageDTO
    {
        public List<MobilePhones> Phones { get; set; }
        public List<Plumbing> Plumbings { get; set; }
        public int Count { get; set; }
        public int MaxPrice { get; set; }
        public PageDTO()
        {
            Phones = new List<MobilePhones>();
            Plumbings = new List<Plumbing>();
        }
    }
}
