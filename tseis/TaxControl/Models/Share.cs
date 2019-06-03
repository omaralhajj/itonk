using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxControl.Models
{
    public class Share
    {
        public int ID { get; set; }
        public int TraderID { get; set; }
        public decimal Value { get; set; }
        public bool SharesForSale { get; set; }
    }
}
