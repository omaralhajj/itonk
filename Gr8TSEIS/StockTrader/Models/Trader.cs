using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrader.Models
{
    public class Trader
    {
        public Guid ID { get; set; }
        public decimal Credit { get; set; }
    }
}
