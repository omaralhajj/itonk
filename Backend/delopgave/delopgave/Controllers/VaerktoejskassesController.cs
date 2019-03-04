using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using delopgave.Models;

namespace delopgave.Controllers
{
    public class VaerktoejskassesController : Controller
    {
        private readonly delopgaveContext _context;

        public VaerktoejskassesController(delopgaveContext context)
        {
            _context = context;
        }

        // GET: Vaerktoejskasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaerktoejskasses.ToListAsync());
        }

        // GET: Vaerktoejskasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoejskasse = await _context.Vaerktoejskasses
                .FirstOrDefaultAsync(m => m.VtkId == id);
            if (vaerktoejskasse == null)
            {
                return NotFound();
            }

            return View(vaerktoejskasse);
        }

        // GET: Vaerktoejskasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaerktoejskasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VtkAnskaffet,VtkEjesAf,VtkFabrikat,VtkFarve,VtkId,VtkModel,VtkSerienummer")] Vaerktoejskasse vaerktoejskasse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaerktoejskasse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaerktoejskasse);
        }

        // GET: Vaerktoejskasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoejskasse = await _context.Vaerktoejskasses.FindAsync(id);
            if (vaerktoejskasse == null)
            {
                return NotFound();
            }
            return View(vaerktoejskasse);
        }

        // POST: Vaerktoejskasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VtkAnskaffet,VtkEjesAf,VtkFabrikat,VtkFarve,VtkId,VtkModel,VtkSerienummer")] Vaerktoejskasse vaerktoejskasse)
        {
            if (id != vaerktoejskasse.VtkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaerktoejskasse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaerktoejskasseExists(vaerktoejskasse.VtkId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vaerktoejskasse);
        }

        // GET: Vaerktoejskasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoejskasse = await _context.Vaerktoejskasses
                .FirstOrDefaultAsync(m => m.VtkId == id);
            if (vaerktoejskasse == null)
            {
                return NotFound();
            }

            return View(vaerktoejskasse);
        }

        // POST: Vaerktoejskasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaerktoejskasse = await _context.Vaerktoejskasses.FindAsync(id);
            _context.Vaerktoejskasses.Remove(vaerktoejskasse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaerktoejskasseExists(int id)
        {
            return _context.Vaerktoejskasses.Any(e => e.VtkId == id);
        }
    }
}
