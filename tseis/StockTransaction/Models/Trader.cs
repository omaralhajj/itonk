﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace StockTransaction.Models
{
    public class Trader
    {
        public int ID { get; set; }
        public decimal Credit { get; set; }
    }
}
