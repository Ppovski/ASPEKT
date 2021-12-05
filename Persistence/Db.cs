using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace test.Models
{
    public partial class AppDbContext  : DbContext
    {
        public AppDbContext ()
        {
        }

        public AppDbContext (DbContextOptions<AppDbContext > options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Country> Country { get; set; }

  

        
}
}