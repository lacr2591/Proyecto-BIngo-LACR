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
    public class TarjetasController : Controller
    {
        private readonly BingoContext _context;

        public TarjetasController(BingoContext context)
        {
            _context = context;
        }

        // GET: Tarjetas
        public async Task<IActionResult> Index()
        {
            var bingoContext = _context.Tarjetas.Include(t => t.IdCombinacionNavigation).Include(t => t.IdJuegoNavigation).Include(t => t.IdJugadorNavigation);
            return View(await bingoContext.ToListAsync());
        }

        // GET: Tarjetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjetas = await _context.Tarjetas
                .Include(t => t.IdCombinacionNavigation)
                .Include(t => t.IdJuegoNavigation)
                .Include(t => t.IdJugadorNavigation)
                .FirstOrDefaultAsync(m => m.IdTarjeta == id);
            if (tarjetas == null)
            {
                return NotFound();
            }

            return View(tarjetas);
        }

        // GET: Tarjetas/Create
        public IActionResult Create()
        {
            ViewData["IdCombinacion"] = new SelectList(_context.Combinaciones, "IdCombinacion", "Numeros");
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "NombreSala");
            ViewData["IdJugador"] = new SelectList(_context.Jugadores, "IdJugador", "Nickname");
            return View();
        }

        // POST: Tarjetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarjeta,IdCombinacion,IdJuego,IdJugador,Ganador")] Tarjetas tarjetas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarjetas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCombinacion"] = new SelectList(_context.Combinaciones, "IdCombinacion", "Numeros", tarjetas.IdCombinacion);
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "NombreSala", tarjetas.IdJuego);
            ViewData["IdJugador"] = new SelectList(_context.Jugadores, "IdJugador", "Nickname", tarjetas.IdJugador);
            return View(tarjetas);
        }

        // GET: Tarjetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjetas = await _context.Tarjetas.FindAsync(id);
            if (tarjetas == null)
            {
                return NotFound();
            }
            ViewData["IdCombinacion"] = new SelectList(_context.Combinaciones, "IdCombinacion", "Numeros", tarjetas.IdCombinacion);
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "NombreSala", tarjetas.IdJuego);
            ViewData["IdJugador"] = new SelectList(_context.Jugadores, "IdJugador", "Nickname", tarjetas.IdJugador);
            return View(tarjetas);
        }

        // POST: Tarjetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarjeta,IdCombinacion,IdJuego,IdJugador,Ganador")] Tarjetas tarjetas)
        {
            if (id != tarjetas.IdTarjeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarjetas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarjetasExists(tarjetas.IdTarjeta))
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
            ViewData["IdCombinacion"] = new SelectList(_context.Combinaciones, "IdCombinacion", "Numeros", tarjetas.IdCombinacion);
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "NombreSala", tarjetas.IdJuego);
            ViewData["IdJugador"] = new SelectList(_context.Jugadores, "IdJugador", "Nickname", tarjetas.IdJugador);
            return View(tarjetas);
        }

        // GET: Tarjetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjetas = await _context.Tarjetas
                .Include(t => t.IdCombinacionNavigation)
                .Include(t => t.IdJuegoNavigation)
                .Include(t => t.IdJugadorNavigation)
                .FirstOrDefaultAsync(m => m.IdTarjeta == id);
            if (tarjetas == null)
            {
                return NotFound();
            }

            return View(tarjetas);
        }

        // POST: Tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarjetas = await _context.Tarjetas.FindAsync(id);
            _context.Tarjetas.Remove(tarjetas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarjetasExists(int id)
        {
            return _context.Tarjetas.Any(e => e.IdTarjeta == id);
        }
    }
}
