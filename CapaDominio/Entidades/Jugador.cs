using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Entidades
{
    public class Jugador
    {
        private Guid idJugador;
        private string nickname;
        private string nombre;

        public string Nombre { get => Nombre; set => Nombre = value; }
        public Guid IdJugador { get => idJugador; set => idJugador = value; }
        public string Nickname { get => nickname; set => nickname = value; }

    }
}
