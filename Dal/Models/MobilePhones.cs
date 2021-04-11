using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMy.Models
{
    public class MobilePhones
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public int VendorCode { get; set; }
        public string ModificationArticle { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<LinkToPhoto> LinkToPhotos { get; set; }
        public string Colour { get; set; }

        public MobilePhones()
        {
            LinkToPhotos = new List<LinkToPhoto>();
        }
    }
}
