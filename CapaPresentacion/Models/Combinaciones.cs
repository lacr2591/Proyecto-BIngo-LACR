using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaPresentacion.Models
{
    public partial class Combinaciones
    {
        public Combinaciones()
        {
            Tarjetas = new HashSet<Tarjetas>();
        }

        public int IdCombinacion { get; set; }
        public string Numeros { get; set; }

        public virtual ICollection<Tarjetas> Tarjetas { get; set; }
    }
}
