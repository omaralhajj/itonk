using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace StockBroker.Models
{
    public class Trader
    {
        public Guid ID { get; set; }
        public decimal Money { get; set; }
    }
}
