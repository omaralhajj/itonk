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
    public class VaerktoejsController : ControllerBase
    {
        private readonly delopgaveContext _context;

        public VaerktoejsController(delopgaveContext context)
        {
            _context = context;
			if (_context.Vaerktoejs.Count() == 0)
            {
                _context.Vaerktoejs.Add(new Vaerktoej { VtModel = "skruenøgle" });
                _context.SaveChanges();
            }
        }

		// GET: api/Vaerktoej
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Vaerktoej>>> GetVaerktoejs()
		{
			return await _context.Vaerktoejs.ToListAsync();
		}

		// GET: api/Vaerktoej/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Vaerktoej>> GetVaerktoej(int id)
		{
			var Vaerktoej = await _context.Vaerktoejs.FindAsync(id);

			if (Vaerktoej == null)
			{
				return NotFound();
			}

			return Vaerktoej;
		}

		// POST: api/Vaerktoejs
		[HttpPost]
		public async Task<ActionResult<Vaerktoej>> PostVaerktoej(Vaerktoej item)
		{
			_context.Vaerktoejs.Add(item);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetVaerktoej), new { id = item.VtId }, item);
		}

		// PUT: api/Todo/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutVaerktoej(int id, Vaerktoej item)
		{
			if (id != item.VtId)
			{
				return BadRequest();
			}

			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/Todo/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteVaerktoej(int id)
		{
			var Vaerktoej = await _context.Vaerktoejs.FindAsync(id);

			if (Vaerktoej == null)
			{
				return NotFound();
			}

			_context.Vaerktoejs.Remove(Vaerktoej);
			await _context.SaveChangesAsync();

			return NoContent();
		}
    }
}
