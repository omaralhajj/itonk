using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareControl.Models;

namespace delopgave.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class ShareController : ControllerBase
    {
        private readonly ShareControllerContext _context;

        public ShareController(ShareControllerContext context)
        {
            _context = context;
        }

		// GET: api/Haandvaerker
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Share>>> GetShares()
		{
			return await _context.Shares.ToListAsync();
		}

		// GET: api/Haandvaerker/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Share>> GetShare(Guid id)
		{
			var share = await _context.Shares.FindAsync(id);

			if (share == null)
			{
				return NotFound();
			}

			return share;
		}

		// POST: api/Haandvaerkers
		[HttpPost]
		public async Task<ActionResult<Share>> PostShare(Share item)
		{
			_context.Shares.Add(item);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(Share), new { id = item.ID }, item);
		}

		// PUT: api/Todo/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutShare(Guid id, Share item)
		{
			if (id != item.ID)
			{
				return BadRequest();
			}

			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/Todo/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteShare(Guid id)
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
