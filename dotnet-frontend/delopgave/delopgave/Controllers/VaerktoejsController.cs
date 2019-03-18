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
    public class VaerktoejsController : Controller
    {
        private readonly delopgaveContext _context;

        public VaerktoejsController(delopgaveContext context)
        {
            _context = context;
        }

        // GET: Vaerktoejs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaerktoejs.ToListAsync());
        }

        // GET: Vaerktoejs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoejs
                .FirstOrDefaultAsync(m => m.VtId == id);
            if (vaerktoej == null)
            {
                return NotFound();
            }

            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaerktoejs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LiggerIvkt,VtAnskaffet,VtFabrikat,VtId,VtModel,VtSerienr,VtType")] Vaerktoej vaerktoej)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaerktoej);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoejs.FindAsync(id);
            if (vaerktoej == null)
            {
                return NotFound();
            }
            return View(vaerktoej);
        }

        // POST: Vaerktoejs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LiggerIvkt,VtAnskaffet,VtFabrikat,VtId,VtModel,VtSerienr,VtType")] Vaerktoej vaerktoej)
        {
            if (id != vaerktoej.VtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaerktoej);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaerktoejExists(vaerktoej.VtId))
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
            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoejs
                .FirstOrDefaultAsync(m => m.VtId == id);
            if (vaerktoej == null)
            {
                return NotFound();
            }

            return View(vaerktoej);
        }

        // POST: Vaerktoejs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaerktoej = await _context.Vaerktoejs.FindAsync(id);
            _context.Vaerktoejs.Remove(vaerktoej);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaerktoejExists(int id)
        {
            return _context.Vaerktoejs.Any(e => e.VtId == id);
        }
    }
}
