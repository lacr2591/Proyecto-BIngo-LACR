using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDominio.Contratos
{
    public  interface IGestorDAO
    {
        void AbrirConexion();
        void CerrarConexion();
        void IniciarTransaccion();
        void TerminarTransaccion();
        void CancelarTransaccion();
    }
}
