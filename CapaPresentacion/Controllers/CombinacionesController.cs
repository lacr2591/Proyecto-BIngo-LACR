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
            string tarjetaNueva = GenerarCombinacion();
            List<string>  tarjetasUsadas = new List<string>();

            foreach (var combinacion in _context.Combinaciones)
            {
                tarjetasUsadas.Add(combinacion.Numeros);
            }
           while(esRepetido(tarjetasUsadas,tarjetaNueva))
            {
                tarjetaNueva = GenerarCombinacion();
            }

            ViewBag.Tarjeta = tarjetaNueva;
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

        public string GenerarCombinacion()
        {
            List<int> columnaB = GenerarColumna(0, 16);
            List<int> columnaI = GenerarColumna(16, 31);
            List<int> columnaN = GenerarColumna(31, 46);
            List<int> columnaG = GenerarColumna(46, 61);
            List<int> columnaO = GenerarColumna(61, 76);

            string combinacion = "";

            for (int i = 0; i < 5; i++)
            {
                combinacion = combinacion + columnaB[i].ToString() + " ";
                combinacion = combinacion + columnaI[i].ToString() + " ";

                if (i != 2)
                    combinacion = combinacion + columnaN[i].ToString() + " ";

                combinacion = combinacion + columnaG[i].ToString() + " ";

                if (i == 4)
                    combinacion = combinacion + columnaO[i].ToString();
                else
                    combinacion = combinacion + columnaO[i].ToString() + " ";
            }
            return combinacion;
        }

        public bool esRepetido(List<string> combinaciones, string combinacionPorAgregar)
        {
            bool sonIguales = false;
            int contadorCoincidencias = 0;

            foreach (var combinacion in combinaciones)
            {
                int[] tempA = Array.ConvertAll(combinacion.Split(), s => int.Parse(s));
                int[] tempB = Array.ConvertAll(combinacionPorAgregar.Split(), s => int.Parse(s));

                contadorCoincidencias = tempA.Intersect(tempB).Count();
                if (contadorCoincidencias == 24)
                {
                    sonIguales = true;
                    break;
                }
                Console.WriteLine(contadorCoincidencias);
            }
            return sonIguales;
        }

        public List<int> GenerarColumna(int rangoI, int rangoF)
        {
            Random aleatorio = new Random();
            List<int> listaNum = new List<int>();

            int temp;
            bool esPrimero = true;
            for (int i = 0; i < 5; i++)
            {
                if (esPrimero)
                {
                    listaNum.Add(aleatorio.Next(rangoI, rangoF));
                    esPrimero = false;
                }
                else
                {
                    temp = aleatorio.Next(rangoI, rangoF);
                    while (listaNum.Contains(temp))
                    {
                        temp = aleatorio.Next(rangoI, rangoF);
                    }
                    listaNum.Add(temp);
                }
            }
            return listaNum;
        }


    }
}
