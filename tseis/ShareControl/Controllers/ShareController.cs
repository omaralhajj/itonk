using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareControl.Models;
using ShareControl.Context;

namespace ShareControl.Controllers
{
	[Route("api/v1")]
	[ApiController]
    public class ShareController : ControllerBase
    {
        private readonly ShareControllerContext _context;

        public ShareController(ShareControllerContext context)
        {
            _context = context;
        }

		// GET: api/v1/shares
		[HttpGet("shares")]
		public async Task<ActionResult<IEnumerable<Share>>> GetShares()
		{
			return await _context.Shares.ToListAsync();
		}

		// GET: api/v1/traders/{traderId}/shares
		[HttpGet("traders/{traderId}/shares")]
		public async Task<ActionResult<IEnumerable<Share>>> GetSharesByTraderId(int traderId) {
			return await _context.Shares.Where(share => share.TraderID == traderId).ToListAsync();
		}

		// GET: api/v1/shares/id
		[HttpGet("shares/{id}")]
		public async Task<ActionResult<Share>> GetShare(int id)
		{
			var share = await _context.Shares.FindAsync(id);

			if (share == null)
			{
				return NotFound();
			}

			return share;
		}

		// POST: api/v1/shares
		[HttpPost("shares")]
		public async Task<ActionResult<Share>> PostShare(Share item)
		{
			_context.Shares.Add(item);
			await _context.SaveChangesAsync();

            return Ok(item);
		}

		// PUT: api/v1/shares/id
		[HttpPut("shares/{id}")]
		public async Task<IActionResult> PutShare(int id, Share item)
		{
			if (id != item.ID)
			{
				return BadRequest();
			}

			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/v1/shares/id
		[HttpDelete("shares/{id}")]
		public async Task<IActionResult> DeleteShare(int id)
		{
			var share = await _context.Shares.FindAsync(id);

			if (share == null)
			{
				return NotFound();
			}

			_context.Shares.Remove(share);
			await _context.SaveChangesAsync();

			return NoContent();
		}
    }
}
