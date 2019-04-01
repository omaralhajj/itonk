using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockBroker.Models;

namespace StockBroker.Controllers
{
    public class StockBrokerController: Controller
    {
        [HttpPut()]
        public async Task<IActionResult> UpdateShare(Guid TraderID, Guid ShareID)
        {
            var tid = TraderID;
            var sid = ShareID;



            return await x;
        }

    }
}
