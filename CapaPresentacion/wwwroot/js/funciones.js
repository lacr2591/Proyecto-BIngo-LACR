﻿
function recargar() {
    let opcion = confirm("Clicka en Aceptar o Cancelar");
    if (opcion) {
        location.reload();
    }
}

function crearFila(identidad, padreContenedor, clase) {
    let newFila = document.createElement("div");
    newFila.id = identidad;
    newFila.className = clase;
    document.getElementById(padreContenedor).appendChild(newFila);
}

function crearColumna(identidad, filaPadre, clase) {
    let newColumna = document.createElement("div");

    newColumna.id = identidad;
    newColumna.className = clase;

    document.getElementById(filaPadre).appendChild(newColumna);
}

function llenarTarjetas(texto, padre) {
    let llenar = document.createTextNode(texto);

    document.getElementById(padre).appendChild(llenar);
}

function llenarCombinaciones(combinaciones, idTarjeta) {
    const arregloNumeros = combinaciones.split(' ');

    let ubicacion = 0;

    for (let i = 0; i < 5; i++) {
        crearFila(i.toString(), 'tarjeta', 'filasNumeros row bg-dark');
        for (let j = 0; j < 5; j++) {
            let ident = i.toString() + j.toString();

            if (i == 2 && j == 2) {
                crearColumna(idTarjeta, i.toString(), 'col mb-1 mt-0 pt-0 p-0 btn-light font-weight-bolder');

                llenarTarjetas(idTarjeta, idTarjeta);
            }
            else {
                crearColumna(ident, i.toString(), 'col mb-1 mt-0 pt-0 p-0 btn-light font-weight-bolder');
                let elemento = document.getElementById(ident);
                elemento.onclick = function () {
                    marcar(ident);
                }

                llenarTarjetas(arregloNumeros[ubicacion].toString(), i.toString() + j.toString());
                ubicacion = ubicacion + 1;
            }

        }
    }
}

function generarTarjeta(combinaciones) {
    //Falta cambiar el ID001 por una variable
    if (document.getElementById('tarjeta') != null) {
        limpiarTarjeta();

        crearFila('encabezadoTarjeta', 'tarjeta', 'encabezadoTarjeta row bg-danger font-weight-bold');
        let clase = "col center";

        crearColumna('columnaB', 'encabezadoTarjeta', clase.toString());
        llenarTarjetas('B', 'columnaB');
        crearColumna('columnaI', 'encabezadoTarjeta', clase.toString());
        llenarTarjetas('I', 'columnaI');
        crearColumna('columnaN', 'encabezadoTarjeta', clase.toString());
        llenarTarjetas('N', 'columnaN');
        crearColumna('columnaG', 'encabezadoTarjeta', clase.toString());
        llenarTarjetas('G', 'columnaG');
        crearColumna('columnaO', 'encabezadoTarjeta', clase.toString());
        llenarTarjetas('O', 'columnaO');

        //falta cambiar variables de entrada (combinacion,idTarjeta)
        llenarCombinaciones(combinaciones, " ");
        if (document.getElementById("temporal")) {
            document.getElementById("temporal").className = combinaciones;
        }


    }
}

function limpiarTarjeta() {
    var n = document.getElementById("tarjeta");

    function limpiarInterno(node) {
        while (node.hasChildNodes()) {
            limpiar(node.firstChild);
        }
    }

    function limpiar(node) {
        while (node.hasChildNodes()) {
            limpiar(node.firstChild);
        }
        node.parentNode.removeChild(node);
    }

    limpiarInterno(n);

}

function marcar(elmnt) {
    if (document.getElementById(elmnt).className != 'col mb-1 mt-0 pt-0 p-0 btn-light font-weight-bolder') {
        document.getElementById(elmnt).className = 'col mb-1 mt-0 pt-0 p-0 btn-light font-weight-bolder';
    }
    else {
        document.getElementById(elmnt).className = 'col mb-1 ml-0 mt-0 pt-0 p-0 btn-warning font-weight-bold';
    }
}

function cargarBolillasTiradas(idSala) {

    let host = JSON.parse(localStorage.getItem('host'));

    if (host.idSala == idSala) {
        if (localStorage.getItem("bolillas")) {
            let bolillas = RecuperarTextoBolilla();
            //CUANDO SE VUELVE
            let temp = new Array();
            bolillas = ' ' + bolillas;
            temp = bolillas.split(' ');
            console.log(temp[temp.length - 1]);

            mostrarBolillaEnPanel(temp[temp.length - 1]);
            console.log(temp);
            /*
             * FALTA IMPLEMENTAR EL MARCADO AUTOMATICO
             * 
            temp.forEach(n => marcarBolillas(n));
            */

        }
        else {
            console.log("funciona");
        }
    }

}





