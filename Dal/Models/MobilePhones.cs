using Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMy.Models
{
    public class MobilePhones:BaseProduct
    {
        public string Photo { get; set; }
        public virtual ICollection<LinkToPhoto> LinkToPhotos { get; set; }

        public MobilePhones()
        {
            LinkToPhotos = new List<LinkToPhoto>();
        }
    }
}
