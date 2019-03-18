using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using delopgave.Models;

namespace delopgave.Models
{
    public class delopgaveContext : DbContext
    {
        public delopgaveContext (DbContextOptions<delopgaveContext> options)
            : base(options)
        {
        }

        public DbSet<delopgave.Models.Haandvaerker> Haandvaerkers { get; set; }

        public DbSet<delopgave.Models.Vaerktoejskasse> Vaerktoejskasses { get; set; }

        public DbSet<delopgave.Models.Vaerktoej> Vaerktoejs { get; set; }
    }
}
