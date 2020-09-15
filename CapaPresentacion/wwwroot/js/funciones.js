function crearFila(identidad,padreContenedor) {
    var newFila = document.createElement("div");
    newFila.id = identidad;
    newFila.className = 'row';
    document.getElementById(padreContenedor).appendChild(newFila);
}


function crearColumna(identidad, filaPadre, clase) {
    var newColumna = document.createElement("div");

    newColumna.id = identidad;
    newColumna.className = clase;

    document.getElementById(filaPadre).appendChild(newColumna);
}

function llenarTarjetas(texto, padre) {
    var llenar = document.createTextNode(texto);

    document.getElementById(padre).appendChild(llenar);  
}
function llenarCombinaciones(combinaciones, idTarjeta) {
    const arregloNumeros = combinaciones.split(' ');

    let ubicacion = 0;

    for (var i = 0; i < 5; i++) {
        crearFila(i.toString(), 'tarjeta');
        for (var j = 0; j < 5; j++) {
            let ident = i.toString() + j.toString();

            if (i==2 && j==2) {
                crearColumna(ident, i.toString(), 'col-sm cantado');

                llenarTarjetas(idTarjeta, i.toString() + j.toString());
            }
            else {
                crearColumna(ident, i.toString(), 'col-sm cantado');
                var elemento = document.getElementById(ident);
                elemento.onclick = function () {
                    marcar(ident);
                }

                llenarTarjetas(arregloNumeros[ubicacion].toString(), i.toString() + j.toString());
                ubicacion = ubicacion + 1;
            }

        }
    }
}

function generarTarjeta() {

    var importarEstilo = document.createElement('link');
    importarEstilo.rel = "stylesheet";
    importarEstilo.href = "/css/tarjetas.css";

    document.getElementsByTagName("head")[0].appendChild(importarEstilo);

    if (document.createStyleSheet) {
        document.createStyleSheet('~/css/site.css');
    }
    else {
        var styles = "@import url('~/css/site.css');";
        var newSS = document.createElement('link');
        newSS.rel = 'stylesheet';
        newSS.href = 'data:text/css,' + escape(styles);
        document.getElementsByTagName("head")[0].appendChild(newSS);
    }



    crearFila('encabezadoTarjeta', 'tarjeta');
    const clase = "col-sm";

    crearColumna('columnaB', 'encabezadoTarjeta',clase.toString());
    llenarTarjetas('B','columnaB');
    crearColumna('columnaI', 'encabezadoTarjeta',clase.toString());
    llenarTarjetas('I', 'columnaI');
    crearColumna('columnaN', 'encabezadoTarjeta',clase.toString());
    llenarTarjetas('N', 'columnaN');
    crearColumna('columnaG', 'encabezadoTarjeta',clase.toString());
    llenarTarjetas('G', 'columnaG');
    crearColumna('columnaO', 'encabezadoTarjeta',clase.toString());
    llenarTarjetas('O', 'columnaO');

    llenarCombinaciones("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24", "id001");
}


function marcar(elmnt) {
    if (document.getElementById(elmnt).className != 'col-sm cantado') {
        document.getElementById(elmnt).className = 'col-sm cantado';
    }
    else {
        document.getElementById(elmnt).className = 'col-sm p-2 btn-dark border-white';
    }
}