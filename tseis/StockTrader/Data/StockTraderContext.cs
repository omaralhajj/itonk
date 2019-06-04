using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTrader.Models;

namespace StockTrader.Context
{
    public class StockTraderContext : DbContext
    {
        public StockTraderContext(DbContextOptions<StockTraderContext> options)
            : base(options)
        {
        }

        public DbSet<Share> Shares { get; set; }

        public DbSet<Trader> Traders { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
