using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CapaPresentacion.Models;
using Microsoft.EntityFrameworkCore;

namespace CapaPresentacion.Controllers
{
    public class LoginController : Controller
    {
        private readonly BingoContext db;
        public LoginController(BingoContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            Juegos ultimoJuego = new Juegos();

            ultimoJuego = db.Juegos.OrderByDescending(x => x.FechaCreacion).First();

            return View(ultimoJuego);

        }
        public async Task<IActionResult> Ingresar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var juegoActual = await db.Juegos
            .FirstOrDefaultAsync(m => m.IdJuego == id);

            if (juegoActual == null)
            {
                return NotFound();
            }
            return View(juegoActual);
        }
        public IActionResult CrearSala(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.RecuperarIdJuego = id.ToString();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearSalaDeJuego([Bind("IdJuego,NombreSala,FechaCreacion,Concluido")] Juegos juegos)
        {
            juegos.Concluido = false;
            juegos.FechaCreacion = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Add(juegos);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(SalaDeJuego), juegos);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult SalaDeJuego(Juegos juego)
        {
            //Validando juego vacio o juego terminado
            if (juego.Concluido == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else if (juego.NombreSala.Length == 0 || juego.IdJuego == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.idJugador = TempData["idJugador"];
                return View(juego);
            }
        }

        public async Task<IActionResult> ReanudarHost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juegoActual = await db.Juegos
            .FirstOrDefaultAsync(m => m.IdJuego == id);

            if (juegoActual == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(SalaDeJuego), juegoActual);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearUsuarioDeJuego(int? id, [Bind("IdJugador,Nickname,Nombre")] Jugadores jugadores)
        {

            if (ModelState.IsValid)
            {
                db.Add(jugadores);
                await db.SaveChangesAsync();

                var idJugador = jugadores.IdJugador;

                var juegoActual = await db.Juegos
                .FirstOrDefaultAsync(m => m.IdJuego == id);

                TempData["idJugador"] = idJugador;

                return RedirectToAction(nameof(SalaDeJuego), juegoActual);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}