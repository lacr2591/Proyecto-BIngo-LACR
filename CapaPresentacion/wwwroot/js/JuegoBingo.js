var connection = new signalR.HubConnectionBuilder()
    .withUrl("/positionhub").build();

connection.start().then(function () {
    console.log("conectado");
})

function marcarBolillas(elmnt) {
    let tmpNum = 0;
    tmpNum = parseInt(elmnt) + 100;

    if (document.getElementById(tmpNum).className != 'btn btn-light') {
        document.getElementById(tmpNum).className = 'btn btn-light';
    }
    else {
        document.getElementById(tmpNum).className = 'btn btn-warning';
    }
    mostrarBolillaEnPanel(elmnt);

    connection.invoke("SendPosition",
        elmnt).catch(function (err) {
            return console.error(err.toString());
        });
    //Envio de mensajes a los otros que no soy yo
}

function GenerarNumeroNoRepetido(numerosTxt, rangoI, rangoF) {
    let acumuladorTexto = "";

    let listaNum = new Array();
    if (numerosTxt == "0") {
        numerosTxt == "";
    } else {
        listaNum = numerosTxt.split(" ");
    }

    let temp = 0;
    try {
        if (listaNum.length <= 149) {
            temp = aleatorio(rangoI, rangoF);
            while (listaNum.indexOf(temp.toString(), 0) != -1) {
                temp = aleatorio(rangoI, rangoF);
            }
            listaNum.push(temp.toString());
        }
        else {
            console.log("DETUVO ERROR " + e);
        }
    } catch (e) {

    }
    console.log(acumuladorTexto.length);

    listaNum.forEach(n => acumuladorTexto = acumuladorTexto + " " + n.toString());
    localStorage.setItem("bolillas", acumuladorTexto);

    console.log(acumuladorTexto.length);
    if (listaNum.length <= 149) {
        return parseInt(listaNum[listaNum.length - 1]);
    }
    else {
        return "FIN";
    }

}

function RecuperarTextoBolilla() {
    let textoNumeros = "0";
    if (localStorage.getItem("bolillas")) {
        textoNumeros = localStorage.getItem("bolillas").toString();
        console.log("si existe");
    }
    else {
        localStorage.setItem("bolillas", "0");
    }

    return textoNumeros;
}
//**FALTAN IMPLEMENTAR
function reanudarBolillas() {

    //Envio de mensajes a los otros que no soy yo
    connection.invoke("SendPosition",
        elmnt).catch(function (err) {
            return console.error(err.toString());
        });
}

function guardarBolillas(bolilla) {


    if (!localStorage.getItem("bolillas")) {
        let bolillas = {
            combinacion: bolilla
        };
        localStorage.setItem("bolillas", JSON.stringify(bolillas));
    }
    else {
        let combinaciones = JSON.parse(localStorage.getItem('bolillas'));
        let arreglo = "";
        arreglo = arreglo + "" + combinaciones.combinacion + " ";

    }


    //Envio de mensajes a los otros que no soy yo
    connection.invoke("SendPosition",
        elmnt).catch(function (err) {
            return console.error(err.toString());
        });
}




function crearHijo(identidad, filaPadre, clase) {
    let newColumna = document.createElement("div");

    newColumna.id = identidad;
    newColumna.className = clase;

    document.getElementById(filaPadre).appendChild(newColumna);
}

function mostrarBolillaEnPanel(numero) {
    document.getElementById("numeroAleatorio").innerHTML = numero;
}



function AgregarAlPanelUsuarios() {
    if (verificarUsuarioExiste) {
        let usuario = JSON.parse(localStorage.getItem("usuario"));
        UsuarioEnPanel(usuario.idJugador, usuario.nickname);
        //INVOKE

    }
}
function conectar() {
    let usuario = JSON.parse(localStorage.getItem("usuario"));

    var idJugador = "";
    var nickname = "";

    idJugador = String(usuario.idJugador);
    nickname = String(usuario.nickname);
    if (document.getElementById("conectarUsuario")) {
        let boton = document.getElementById("conectarUsuario");
        let padre = boton.parentNode;
        padre.removeChild(boton);
    }
    connection.invoke("SendUser",idJugador, nickname).catch(function (err) {
            return console.error(err.toString());
    });

    
}

function UsuarioEnPanel(idUsuario, nickname) {
    let padre = document.getElementById("PanelUsuarios");
    let usuario = document.createElement("div");
    usuario.className = "bg-warning";
    usuario.id = idUsuario;
    usuario.innerHTML = nickname;
    padre.appendChild(usuario);
}

connection.on("ReceivePosition", function (elmnt) {
    console.log(elmnt);
    let tmpNum = 0;
    tmpNum = parseInt(elmnt) + 100;

    if (document.getElementById(tmpNum).className != 'btn btn-light') {
        document.getElementById(tmpNum).className = 'btn btn-light';
    }
    else {
        document.getElementById(tmpNum).className = 'btn btn-warning';
    }
    mostrarBolillaEnPanel(elmnt);
})

connection.on("RecibirUsuario", function (idJugador, jugador) {
    UsuarioEnPanel(idJugador, jugador);
})
