using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMy.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<MobilePhones> MobilePhones { get; set; }
        public DbSet<LinkToPhoto> Links { get; set; }
    }
}
