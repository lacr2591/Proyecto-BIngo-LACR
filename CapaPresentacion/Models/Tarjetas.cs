using System;
using System.Collections.Generic;

namespace CapaPresentacion.Models
{
    public partial class Tarjetas
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
