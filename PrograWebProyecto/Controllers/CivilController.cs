using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrograWebProyecto.Models;

namespace PrograWebProyecto.Controllers
{
    public class CivilController : Controller
    {
        private readonly AppDbContext _context;

        public CivilController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Civil
        public async Task<IActionResult> Index()
        {
              return _context.tblCivil != null ? 
                          View(await _context.tblCivil.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.tblCivil'  is null.");
        }

        // GET: Civil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblCivil == null)
            {
                return NotFound();
            }

            var civil = await _context.tblCivil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (civil == null)
            {
                return NotFound();
            }

            return View(civil);
        }

        // GET: Civil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Civil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estado")] Civil civil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(civil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(civil);
        }

        // GET: Civil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblCivil == null)
            {
                return NotFound();
            }

            var civil = await _context.tblCivil.FindAsync(id);
            if (civil == null)
            {
                return NotFound();
            }
            return View(civil);
        }

        // POST: Civil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estado")] Civil civil)
        {
            if (id != civil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(civil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CivilExists(civil.Id))
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
            return View(civil);
        }

        // GET: Civil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblCivil == null)
            {
                return NotFound();
            }

            var civil = await _context.tblCivil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (civil == null)
            {
                return NotFound();
            }

            return View(civil);
        }

        // POST: Civil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblCivil == null)
            {
                return Problem("Entity set 'AppDbContext.tblCivil'  is null.");
            }
            var civil = await _context.tblCivil.FindAsync(id);
            if (civil != null)
            {
                _context.tblCivil.Remove(civil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CivilExists(int id)
        {
          return (_context.tblCivil?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
