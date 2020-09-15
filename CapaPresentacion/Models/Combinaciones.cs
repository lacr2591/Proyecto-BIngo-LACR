using System;
using System.Collections;
using System.Collections.Generic;

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

        public string GenerarCombinaciones()
        {
            Random generador = new Random();
            string combinaciones = "";

            for (int posicion = 0; posicion < 24; posicion++)
            {
                if (posicion<=4)
                {
                    if (posicion==0)
                    {
                        combinaciones = combinaciones + generador.Next(0, 16).ToString();
                    }
                    else
                    {
                        combinaciones = combinaciones + " " + generador.Next(0, 16).ToString();
                    }
                    
                }
                else if (posicion<=9)
                {
                    combinaciones = combinaciones + " " + generador.Next(16, 31).ToString();
                }
                else if (posicion<=13)
                {
                    combinaciones = combinaciones + " " + generador.Next(31, 46).ToString();
                }
                else if (posicion<=18)
                {
                    combinaciones = combinaciones + " " + generador.Next(46, 61).ToString();
                }
                else if (posicion<=23)
                {
                    combinaciones = combinaciones + " " + generador.Next(61, 76).ToString();
                }
            }

            return combinaciones;
        }

       

        public virtual ICollection<Tarjetas> Tarjetas { get; set; }
    }
}
