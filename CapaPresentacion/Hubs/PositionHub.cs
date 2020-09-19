using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaPresentacion.Hubs
{
    public class PositionHub : Hub
    {
        public async Task SendPosition(int elmnt)
        {
            await Clients.Others.SendAsync("ReceivePosition", elmnt);

        }
        public async Task SendUser(string idJugador, string jugador)
        {
            await Clients.Others.SendAsync("RecibirUsuario", idJugador,jugador);

        }


    }
}
