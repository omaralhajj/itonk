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
    public class VaerktoejskassesController : ControllerBase
    {
        private readonly delopgaveContext _context;

        public VaerktoejskassesController(delopgaveContext context)
        {
            _context = context;
			if (_context.Vaerktoejskasses.Count() == 0)
            {
                _context.Vaerktoejskasses.Add(new Vaerktoejskasse { VtkEjesAf = "Omar" });
                _context.SaveChanges();
            }
        }

		// GET: api/Vaerktoejskasse
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Vaerktoejskasse>>> GetVaerktoejskasses()
		{
			return await _context.Vaerktoejskasses.ToListAsync();
		}

		// GET: api/Vaerktoejskasse/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Vaerktoejskasse>> GetVaerktoej(int id)
		{
			var Vaerktoejskasse = await _context.Vaerktoejskasses.FindAsync(id);

			if (Vaerktoejskasse == null)
			{
				return NotFound();
			}

			return Vaerktoejskasse;
		}

		// POST: api/Vaerktoejskasses
		[HttpPost]
		public async Task<ActionResult<Vaerktoejskasse>> PostVaerktoej(Vaerktoejskasse item)
		{
			_context.Vaerktoejskasses.Add(item);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetVaerktoej), new { id = item.VtkId }, item);
		}

		// PUT: api/Todo/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutVaerktoej(int id, Vaerktoejskasse item)
		{
			if (id != item.VtkId)
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
			var Vaerktoejskasse = await _context.Vaerktoejskasses.FindAsync(id);

			if (Vaerktoejskasse == null)
			{
				return NotFound();
			}

			_context.Vaerktoejskasses.Remove(Vaerktoejskasse);
			await _context.SaveChangesAsync();

			return NoContent();
		}
    }
}
