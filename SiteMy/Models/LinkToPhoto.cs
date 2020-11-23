using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMy.Models
{
    public class LinkToPhoto
    {
        [Key]
        public int Id { get; set; }
        public MobilePhones Phone { get; set; }
        public string Link { get; set; }

    }
}
