using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Transaction
    {
        public Guid ID { get; set; }
        public Guid BuyerID { get; set; }
        public Guid ShareID { get; set; }
        public Guid SellerID { get; set; }
        public decimal TransferValue { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
