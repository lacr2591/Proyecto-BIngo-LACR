using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapaPresentacion.Models;

namespace CapaPresentacion.Controllers
{
    public class CombinacionesController : Controller
    {
        private readonly BingoContext _context;

        public CombinacionesController(BingoContext context)
        {
            _context = context;
        }

        // GET: Combinaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Combinaciones.ToListAsync());
        }

        // GET: Combinaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combinaciones = await _context.Combinaciones
                .FirstOrDefaultAsync(m => m.IdCombinacion == id);
            if (combinaciones == null)
            {
                return NotFound();
            }

            return View(combinaciones);
        }

        // GET: Combinaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Combinaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCombinacion,Numeros")] Combinaciones combinaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combinaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(combinaciones);
        }

        // GET: Combinaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combinaciones = await _context.Combinaciones.FindAsync(id);
            if (combinaciones == null)
            {
                return NotFound();
            }
            return View(combinaciones);
        }

        // POST: Combinaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCombinacion,Numeros")] Combinaciones combinaciones)
        {
            if (id != combinaciones.IdCombinacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combinaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombinacionesExists(combinaciones.IdCombinacion))
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
            return View(combinaciones);
        }

        // GET: Combinaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combinaciones = await _context.Combinaciones
                .FirstOrDefaultAsync(m => m.IdCombinacion == id);
            if (combinaciones == null)
            {
                return NotFound();
            }

            return View(combinaciones);
        }

        // POST: Combinaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var combinaciones = await _context.Combinaciones.FindAsync(id);
            _context.Combinaciones.Remove(combinaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CombinacionesExists(int id)
        {
            return _context.Combinaciones.Any(e => e.IdCombinacion == id);
        }
    }
}
