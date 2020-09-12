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
    public class JuegosController : Controller
    {
        private readonly BingoContext _context;

        public JuegosController(BingoContext context)
        {
            _context = context;
        }

        // GET: Juegos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Juegos.ToListAsync());
        }

        // GET: Juegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juegos = await _context.Juegos
                .FirstOrDefaultAsync(m => m.IdJuego == id);
            if (juegos == null)
            {
                return NotFound();
            }

            return View(juegos);
        }

        // GET: Juegos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juegos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJuego,NombreSala,FechaCreacion,Concluido")] Juegos juegos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juegos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juegos);
        }

        // GET: Juegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juegos = await _context.Juegos.FindAsync(id);
            if (juegos == null)
            {
                return NotFound();
            }
            return View(juegos);
        }

        // POST: Juegos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJuego,NombreSala,FechaCreacion,Concluido")] Juegos juegos)
        {
            if (id != juegos.IdJuego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juegos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuegosExists(juegos.IdJuego))
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
            return View(juegos);
        }

        // GET: Juegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juegos = await _context.Juegos
                .FirstOrDefaultAsync(m => m.IdJuego == id);
            if (juegos == null)
            {
                return NotFound();
            }

            return View(juegos);
        }

        // POST: Juegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juegos = await _context.Juegos.FindAsync(id);
            _context.Juegos.Remove(juegos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegosExists(int id)
        {
            return _context.Juegos.Any(e => e.IdJuego == id);
        }
    }
}
