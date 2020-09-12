using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaPersistencia.SQLServerDAO;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTestGestorDAO
    {
        [TestMethod]
        public void UnitTest_AbrirConexion()
        {
            CapaPersistencia.SQLServerDAO.GestorDAO gestor = new CapaPersistencia.SQLServerDAO.GestorDAO();
            gestor.AbrirConexion();
        }

        [TestMethod]
        public void UnitTest_CerrarConexion()
        {
            CapaPersistencia.SQLServerDAO.GestorDAO gestor = new CapaPersistencia.SQLServerDAO.GestorDAO();
            gestor.AbrirConexion();
            gestor.CerrarConexion();
        }


    }
}
