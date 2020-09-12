using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Entidades
{
    public class Tarjeta
    {
        private Guid idTarjeta;
        private Combinacion combinacion;
        private Juego juego;
        private Jugador jugador;
        private char ganador;

        public Guid IdTarjeta { get => idTarjeta; set => idTarjeta = value; }
        public Combinacion Combinacion { get => combinacion; set => combinacion = value; }
        public Juego Juego { get => juego; set => juego = value; }
        public Jugador Jugador { get => jugador; set => jugador = value; }
        public char Ganador { get => ganador; set => ganador = value; }
    }
}
