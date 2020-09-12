using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Entidades
{
    public class Combinacion
    {
        private Guid idCombinacion;
        private string numeros;

        public Guid IdCombinacion { get => idCombinacion; set => idCombinacion = value; }
        public string Numeros { get => numeros; set => numeros = value; }
    }
}
