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
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
              return _context.tblUser != null ? 
                          View(await _context.tblUser.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.tblUser'  is null.");
        }

       

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblUser == null)
            {
                return NotFound();
            }

            var user = await _context.tblUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData ["Cargos"] = new SelectList(_context.tblCargo.ToList(),"Id","NombreCargo");
            ViewData["Generos"] = new SelectList(_context.tblGenero.ToList(), "Id", "Descripcion");
            ViewData["Turnos"] = new SelectList(_context.tblTurno.ToList(), "Id", "Descripcion");
            ViewData["Civil"] = new SelectList(_context.tblCivil.ToList(), "Id", "Estado");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rut,Name,LastName,Email,Username,Password,Telefono,IdCargo,IdTurno,IdGenero,IdCivil")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblUser == null)
            {
                return NotFound();
            }

            var user = await _context.tblUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rut,Name,LastName,Email,Username,Password,Telefono,IdCargo,IdTurno,IdGenero,IdCivil")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblUser == null)
            {
                return NotFound();
            }

            var user = await _context.tblUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblUser == null)
            {
                return Problem("Entity set 'AppDbContext.tblUser'  is null.");
            }
            var user = await _context.tblUser.FindAsync(id);
            if (user != null)
            {
                _context.tblUser.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.tblUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
