function GuardarDatosUsuario() {
    let combinacion = document.getElementById('temporal').className;
    let apodo = document.getElementById('nickname').value;
    let name = document.getElementById('nombre').value

    let usuario = {
        nickname: apodo,
        nombre: name,
        combinacion:combinacion
    };
        localStorage.setItem("usuario", JSON.stringify(usuario)); 
}

function GuardarDatosHost() {
    let idSala1 = document.getElementById('idSala').innerHTML;
    let nombreSala1 = document.getElementById('nombreSala').innerHTML;
    let fechaCreacion1 = document.getElementById('fechaCreacion').innerHTML;
    let concluido1 = document.getElementById('concluido').innerHTML;

    let host = {
        idSala: idSala1,
        nombreSala: nombreSala1,
        fechaCreacion: fechaCreacion1,
        concluido: concluido1
    };
    localStorage.setItem("host", JSON.stringify(host));

}
function ReanudarSesion(idSesion) {
    let host = JSON.parse(localStorage.getItem('host'));
    console.log(host.idSala);
    console.log(host.nombreSala);
    console.log(host.fechaCreacion);
    console.log(host.concluido);
    console.log(host);

    if (idSesion==host.idSala) {
        let padre = document.getElementById("reanudarSesion");
        let hijo = document.createElement("a");
        hijo.innerHTML = "ReanudarSesion";
        hijo.href = "/Login/ReanudarHost/"+idSesion;
        padre.insertBefore(hijo,padre.lastElementChild);
    }
}



