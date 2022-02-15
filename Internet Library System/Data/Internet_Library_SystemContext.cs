using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Internet_Library_System.Models;

namespace Internet_Library_System.Data
{
    public class Internet_Library_SystemContext : DbContext
    {
        public Internet_Library_SystemContext (DbContextOptions<Internet_Library_SystemContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Internet_Library_System.Models.Books> Books { get; set; }

        public DbSet<Internet_Library_System.Models.LibraryCardOwners> LibraryCardOwners { get; set; }

        public DbSet<Internet_Library_System.Models.BookKeepers> BookKeepers { get; set; }
    }
}
