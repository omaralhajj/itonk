using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTransaction.Models;

namespace StockTransaction.Context
{
    public class TransactionsControllerContext : DbContext
    {
        public TransactionsControllerContext(DbContextOptions<TransactionsControllerContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Share> Shares { get; set; }

        public DbSet<Models.Trader> Traders { get; set; }

        public DbSet<Models.Transaction> Transactions { get; set; }
    }
}
