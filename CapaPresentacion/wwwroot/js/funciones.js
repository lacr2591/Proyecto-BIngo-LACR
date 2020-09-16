function crearFila(identidad, padreContenedor) {
    let newFila = document.createElement("div");
    newFila.id = identidad;
    newFila.className = 'row';
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
        crearFila(i.toString(), 'tarjeta');
        for (let j = 0; j < 5; j++) {
            let ident = i.toString() + j.toString();

            if (i == 2 && j == 2) {
                crearColumna(idTarjeta, i.toString(), 'col-sm cantado');

                llenarTarjetas(idTarjeta, idTarjeta);
            }
            else {
                crearColumna(ident, i.toString(), 'col-sm cantado');
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
    console.log("HOLA MUNDO");
    if (document.getElementById("id001") == null) {



        let importarEstilo = document.createElement('link');
        importarEstilo.rel = "stylesheet";
        importarEstilo.href = "/css/tarjetas.css";

        document.getElementsByTagName("head")[0].appendChild(importarEstilo);

        if (document.createStyleSheet) {
            document.createStyleSheet('~/css/site.css');
        }
        else {
            let styles = "@import url('~/css/site.css');";
            let newSS = document.createElement('link');
            newSS.rel = 'stylesheet';
            newSS.href = 'data:text/css,' + escape(styles);
            document.getElementsByTagName("head")[0].appendChild(newSS);
        }



        crearFila('encabezadoTarjeta', 'tarjeta');
        let clase = "col-sm";

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
        llenarCombinaciones(combinaciones, "id001");
    }
}


function marcar(elmnt) {
    if (document.getElementById(elmnt).className != 'col-sm cantado') {
        document.getElementById(elmnt).className = 'col-sm cantado';
    }
    else {
        document.getElementById(elmnt).className = 'col-sm p-2 btn-dark border-white';
    }
}