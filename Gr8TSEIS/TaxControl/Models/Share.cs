using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxControl.Models
{
    public class Share
    {
        public Guid ID { get; set; }
        public Guid TraderID { get; set; }
        public decimal Value { get; set; }
        public bool SharesForSale { get; set; }
    }
}
