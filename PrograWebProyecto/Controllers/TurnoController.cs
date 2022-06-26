﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrograWebProyecto.Models;

namespace PrograWebProyecto.Controllers
{
    public class TurnoController : Controller
    {
        private readonly AppDbContext _context;

        public TurnoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Turno
        public async Task<IActionResult> Index()
        {
              return _context.tblTurno != null ? 
                          View(await _context.tblTurno.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.tblTurno'  is null.");
        }

        // GET: Turno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblTurno == null)
            {
                return NotFound();
            }

            var turno = await _context.tblTurno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // GET: Turno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turno);
        }

        // GET: Turno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblTurno == null)
            {
                return NotFound();
            }

            var turno = await _context.tblTurno.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            return View(turno);
        }

        // POST: Turno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.Id))
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
            return View(turno);
        }

        // GET: Turno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblTurno == null)
            {
                return NotFound();
            }

            var turno = await _context.tblTurno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblTurno == null)
            {
                return Problem("Entity set 'AppDbContext.tblTurno'  is null.");
            }
            var turno = await _context.tblTurno.FindAsync(id);
            if (turno != null)
            {
                _context.tblTurno.Remove(turno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
          return (_context.tblTurno?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
