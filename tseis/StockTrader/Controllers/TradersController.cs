using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockTrader.Context;
using StockTrader.Models;

namespace StockTrader.Controllers
{
    [Route("api/v1")]
    public class TradersController : Controller
    {
        private readonly StockTraderContext _context;
        public TradersController(StockTraderContext context)
        {
            _context = context;
        }

        [HttpGet("traders/{id}")]
        public async Task<ActionResult<Trader>> GetTraderById([FromRoute] int id)
        {
            return await _context.Traders.SingleAsync(trader => trader.ID == id);
        }

        [HttpGet("traders")]
        public async Task<ActionResult<IEnumerable<Trader>>> GetTraders()
        {
            return await _context.Traders.ToListAsync();
        }

        [HttpPost("traders")]
        public async Task<ActionResult<Trader>> CreateTrader([FromBody] [Required] Trader trader)
        {
            _context.Traders.Add(trader);
            await _context.SaveChangesAsync();

            return Ok(trader);
        }

        [HttpPut("traders/{id}")]
        public async Task<IActionResult> UpdateTrader([FromRoute] int id, [FromBody] [Required] Trader trader)
        {
            if (id != trader.ID)
            {
                return BadRequest();
            }

            _context.Entry(trader).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}