using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DelprojektApi.Models;

namespace DelprojektApi.Models
{
    public class delopgaveContext : DbContext
    {
        public delopgaveContext (DbContextOptions<delopgaveContext> options)
            : base(options)
        {
        }

        public DbSet<Haandvaerker> Haandvaerkers { get; set; }

        public DbSet<Vaerktoejskasse> Vaerktoejskasses { get; set; }

        public DbSet<Vaerktoej> Vaerktoejs { get; set; }
    }
}
