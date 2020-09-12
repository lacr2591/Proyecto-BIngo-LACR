using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Entidades
{
    public class Juego
    {
        private Guid idJuego;
        private string nombreSala;
        private DateTime fechaCreacion;
        private char concluido;

        public Guid IdJuego { get => idJuego; set => idJuego = value; }
        public string NombreSala { get => nombreSala; set => nombreSala = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public char Concluido { get => concluido; set => concluido = value; }
    }
}
