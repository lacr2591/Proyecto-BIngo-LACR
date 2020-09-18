using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaPresentacion.Models
{
    public class Login
    {
        public int IdTarjeta { get; set; }
        public int IdCombinacion { get; set; }
        public int IdJuego { get; set; }
        public int IdJugador { get; set; }
        public bool Ganador { get; set; }

        public virtual Combinaciones IdCombinacionNavigation { get; set; }
        public virtual Juegos IdJuegoNavigation { get; set; }
        public virtual Jugadores IdJugadorNavigation { get; set; }

    }
}
