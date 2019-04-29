using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockBroker.Models
{
    public class DBmodel : DbContext
    {
        public DBmodel(DbContextOptions<DBmodel> options)
            : base(options)
        {
        }

        public DbSet<Models.Share> Shares { get; set; }

        public DbSet<Models.Trader> Traders { get; set; }

        public DbSet<Models.Transaction> Transactions { get; set; }
    }
}
