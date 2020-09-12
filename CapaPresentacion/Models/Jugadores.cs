using System;
using System.Collections.Generic;

namespace CapaPresentacion.Models
{
    public partial class Jugadores
    {
        public Jugadores()
        {
            Tarjetas = new HashSet<Tarjetas>();
        }

        public int IdJugador { get; set; }
        public string Nickname { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tarjetas> Tarjetas { get; set; }
    }
}
