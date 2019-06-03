using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxControl.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int BuyerID { get; set; }
        public int ShareID { get; set; }
        public int SellerID { get; set; }
        public decimal TransferValue { get; set; }
        public DateTime TimeStamp { get; set; }

        internal static Task FindAsync(object iD)
        {
            throw new NotImplementedException();
        }
    }
}
