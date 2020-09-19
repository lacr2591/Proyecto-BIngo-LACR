function GuardarDatosUsuario() {
    let combinacion = document.getElementById('temporal').className;
    let apodo = document.getElementById('Nickname').value;
    let name = document.getElementById('Nombre').value;
    eliminarBolillas();
    console.log("se elimino");
    let usuario = {
        nickname: apodo,
        nombre: name,
        combinacion: combinacion
    };
    localStorage.setItem("usuario", JSON.stringify(usuario));
}

function GuardarDatosHost(idJuego) {
    console.log(idJuego);
    eliminarBolillas();
    console.log("se elimino");

    let concluido1 = false;

    let host = {
        idSala: idJuego,
        concluido: concluido1
    };
    localStorage.setItem("host", JSON.stringify(host));
}

function ReanudarSesion(idSesion) {
    let host = JSON.parse(localStorage.getItem('host'));

    crearEnlaceReanudar(idSesion, host.idSala);
}

function crearEnlaceReanudar(idSala, idHost) {
    if (idSala == idHost) {
        let padre = document.getElementById("reanudarSesion");
        let hijo = document.createElement("a");
        hijo.innerHTML = "ReanudarSesion";
        hijo.href = "/Login/ReanudarHost/" + idSala;
        padre.insertBefore(hijo, padre.lastChild);
    }
}
function crearBotonSacarBolilla(idSala) {
    let host = JSON.parse(localStorage.getItem('host'));

    if (idSala == host.idSala) {
        let padre = document.getElementById("panelNumerosAleatorios");
        let hijo = document.createElement("div");
        hijo.className = "row";
        hijo.id = "botonTirarBolilla";

        padre.insertBefore(hijo, padre.lastChild);

        let boton = document.createElement("div");
        boton.className = "col-sm btn btn-dark";
        boton.id = "TirarBolillas";
        boton.innerHTML = "TIRAR BOLILLA";
        boton.onclick = function () {
            //agregar CADENA DE TEXTO
            let temp;
            temp = GenerarNumeroNoRepetido(RecuperarTextoBolilla(), 1, 75);
            if (temp != "FIN") {
                marcarBolillas(temp);
            }
            else {
                console.log("Acabo el juego");
                mostrarBolillaEnPanel("FIN");
            }
        }

        hijo.appendChild(boton);


        if (localStorage.getItem("bolillas")) {
            //CUANDO SE VUELVE
            cargarBolillasTiradas(idSala);

        }
        else {
            console.log("Sin bolillas");
        }
    }
}
function CrearTarjetaBingo() {
    if (verificarUsuarioExiste) {
        let usuario = JSON.parse(localStorage.getItem("usuario"));
        generarTarjeta(String(usuario.combinacion));

    }
}

function eliminarBolillas() {
    localStorage.removeItem("bolillas");
}
function eliminarUsuario() {
    localStorage.removeItem("usuario");
}

function GuardarDatosUsuarioMasId(idJugador) {
    if (verificarUsuarioExiste) {
        let usuarioTmp = JSON.parse(localStorage.getItem("usuario"));
        console.log(usuarioTmp);

        let usuario = {
            idJugador: idJugador,
            nickname: usuarioTmp.nickname,
            nombre: usuarioTmp.nombre,
            combinacion: usuarioTmp.combinacion
        };

        localStorage.setItem("usuario", JSON.stringify(usuario));
    }

}
function verificarUsuarioExiste() {
    let existe = false;
    if (localStorage.getItem = "Usuario") {
        existe = true;
    }
    return existe;
}
