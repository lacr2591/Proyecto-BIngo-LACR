function GenerarCombinacion()
{
    let columnaB = GenerarColumna(1, 16);
    let columnaI = GenerarColumna(16, 31);
    let columnaN = GenerarColumna(31, 46);
    let columnaG = GenerarColumna(46, 61);
    let columnaO = GenerarColumna(61, 76);

    let combinacion = "";

    for (let i = 0; i < 5; i++)
    {
        combinacion = combinacion + "" + columnaB[i] + " ";
        combinacion = combinacion + "" + columnaI[i] + " ";

        if (i != 2)
            combinacion = combinacion + "" + columnaN[i] + " ";

        combinacion = combinacion + "" + columnaG[i]+ " ";

        if (i == 4)
            combinacion = combinacion + "" + columnaO[i];
        else
            combinacion = combinacion + "" + columnaO[i] + " ";
    }
    return combinacion;
}

function GenerarColumna(rangoI, rangoF)
{

    let listaNum = new Array();

    let temp;
    let esPrimero = true;
    for (let i = 0; i < 5; i++)
    {
        if (esPrimero) {
            listaNum.push(aleatorio(rangoI, rangoF));
            esPrimero = false;
        }
        else {
            temp = aleatorio(rangoI, rangoF);
            while (listaNum.indexOf(temp,0)!=-1) {
                temp = aleatorio(rangoI, rangoF);
            }
            listaNum.push(temp);
        }
    }
    return listaNum;
}

function aleatorio(minimo, maximo) {
    return Math.floor(Math.random() * ((maximo + 1) - minimo) + minimo);
}