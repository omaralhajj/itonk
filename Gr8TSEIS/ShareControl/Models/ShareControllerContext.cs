using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShareControl.Models
{
    public class ShareControllerContext : DbContext
    {
        public ShareControllerContext(DbContextOptions<ShareControllerContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Share> Shares { get; set; }

        public DbSet<Models.Trader> Traders { get; set; }

        public DbSet<Models.Transaction> Transactions { get; set; }
    }
}
