using System;
using System.Collections.Generic;

namespace CapaPresentacion.Models
{
    public partial class Juegos
    {
        public Juegos()
        {
            Tarjetas = new HashSet<Tarjetas>();
        }

        public int IdJuego { get; set; }
        public string NombreSala { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Concluido { get; set; }

        public virtual ICollection<Tarjetas> Tarjetas { get; set; }
    }
}
