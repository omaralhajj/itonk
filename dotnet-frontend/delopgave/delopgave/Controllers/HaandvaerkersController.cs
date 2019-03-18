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
    public class HaandvaerkersController : Controller
    {
        private readonly delopgaveContext _context;

        public HaandvaerkersController(delopgaveContext context)
        {
            _context = context;
        }

        // GET: Haandvaerkers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Haandvaerkers.ToListAsync());
        }

        // GET: Haandvaerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haandvaerker = await _context.Haandvaerkers
                .FirstOrDefaultAsync(m => m.HaandvaerkerId == id);
            if (haandvaerker == null)
            {
                return NotFound();
            }

            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haandvaerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HvAnsaettelsedatao,HvEfternavn,HvFagomraade,HvFornavn,HaandvaerkerId")] Haandvaerker haandvaerker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haandvaerker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haandvaerker = await _context.Haandvaerkers.FindAsync(id);
            if (haandvaerker == null)
            {
                return NotFound();
            }
            return View(haandvaerker);
        }

        // POST: Haandvaerkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HvAnsaettelsedatao,HvEfternavn,HvFagomraade,HvFornavn,HaandvaerkerId")] Haandvaerker haandvaerker)
        {
            if (id != haandvaerker.HaandvaerkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haandvaerker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaandvaerkerExists(haandvaerker.HaandvaerkerId))
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
            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haandvaerker = await _context.Haandvaerkers
                .FirstOrDefaultAsync(m => m.HaandvaerkerId == id);
            if (haandvaerker == null)
            {
                return NotFound();
            }

            return View(haandvaerker);
        }

        // POST: Haandvaerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var haandvaerker = await _context.Haandvaerkers.FindAsync(id);
            _context.Haandvaerkers.Remove(haandvaerker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaandvaerkerExists(int id)
        {
            return _context.Haandvaerkers.Any(e => e.HaandvaerkerId == id);
        }
    }
}
