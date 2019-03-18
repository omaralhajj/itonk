using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using delopgave.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace delopgave.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class HaandvaerkersController : ControllerBase
    {
        private readonly delopgaveContext _context;

        public HaandvaerkersController(delopgaveContext context)
        {
            _context = context;
			if (_context.Haandvaerkers.Count() == 0)
            {
                _context.Haandvaerkers.Add(new Haandvaerker { HvFornavn = "Omar" });
                _context.SaveChanges();
            }
        }

		// GET: api/Haandvaerker
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Haandvaerker>>> GetHaandvaerkers()
		{
			return await _context.Haandvaerkers.ToListAsync();
		}

		// GET: api/Haandvaerker/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Haandvaerker>> GetHaandvaerker(int id)
		{
			var haandvaerker = await _context.Haandvaerkers.FindAsync(id);

			if (haandvaerker == null)
			{
				return NotFound();
			}

			return haandvaerker;
		}

		// POST: api/Haandvaerkers
		[HttpPost]
		public async Task<ActionResult<Haandvaerker>> PostHaandvaerker(Haandvaerker item)
		{
			_context.Haandvaerkers.Add(item);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetHaandvaerker), new { id = item.HaandvaerkerId }, item);
		}

		// PUT: api/Todo/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutHaandvaerker(int id, Haandvaerker item)
		{
			if (id != item.HaandvaerkerId)
			{
				return BadRequest();
			}

			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/Todo/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteHaandvaerker(int id)
		{
			var haandvaerker = await _context.Haandvaerkers.FindAsync(id);

			if (haandvaerker == null)
			{
				return NotFound();
			}

			_context.Haandvaerkers.Remove(haandvaerker);
			await _context.SaveChangesAsync();

			return NoContent();
		}
    }
}
