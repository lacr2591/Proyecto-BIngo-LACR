using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CapaDominio.Contratos;
using System.Data.SqlClient;
using System.Data;

namespace CapaPersistencia.SQLServerDAO
{
    public class GestorDAO:IGestorDAO
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion;

        public void AbrirConexion()
        {
            try
            {
                conexion = new SqlConnection();
                conexion.ConnectionString = "Data Source=DESKTOP-TV575S0;Initial Catalog=Bingo;Integrated Security=true";
                conexion.Open();
            }

            catch (Exception err)
            {
                throw new Exception("Error en la conexion con la Base de Datos.", err);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
            }

            catch (Exception err)
            {
                throw new Exception("Error al cerrar la conexion con la base de datos.", err);
            }
        }

        public void IniciarTransaccion()
        {
            try
            {
                AbrirConexion();
                transaccion = conexion.BeginTransaction();
            }

            catch (Exception err)
            {
                throw new Exception("Error al iniciar la transaccion en la base de datos.", err);
            }
        }

        public void TerminarTransaccion()
        {
            try
            {
                transaccion.Commit();
                conexion.Close();
            }

            catch (Exception err)
            {
                throw new Exception("Error al iniciar la transaccion en la base de datos.", err);
            }
        }

        public void CancelarTransaccion()
        {
            try
            {
                transaccion.Commit();
                conexion.Close();
            }

            catch (Exception err)
            {
                throw new Exception("Error al iniciar la transaccion en la base de datos.", err);
            }
        }

        public SqlDataReader EjecutarConsulta(String sentenciaSQL)
        {
            try
            {
                SqlCommand comandoSQL = conexion.CreateCommand();
                if (transaccion != null)
                {
                    comandoSQL.Transaction = transaccion;
                }
                comandoSQL.CommandText = sentenciaSQL;
                comandoSQL.CommandType = CommandType.Text;
                return comandoSQL.ExecuteReader();
            }

            catch (Exception err)
            {
                throw new Exception("Error al ejecutar consulta en la base de datos.", err);
            }
        }

        public SqlDataReader EjecutarConsultaDeProcedimientoAlmacenado(String procedimientoAlmacenado)
        {
            try
            {
                SqlCommand comandoSQL = conexion.CreateCommand();
                if (transaccion != null)
                {
                    comandoSQL.Transaction = transaccion;
                }
                comandoSQL.CommandText = procedimientoAlmacenado;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                return comandoSQL.ExecuteReader();
            }

            catch (Exception err)
            {
                throw new Exception("Error al ejecutar consulta en la base de datos.", err);
            }
        }

        public SqlCommand ObtenerComandoSQL(String sentenciaSQL)
        {
            try
            {
                SqlCommand comandoSQL = conexion.CreateCommand();
                if (transaccion != null)
                {
                    comandoSQL.Transaction = transaccion;
                }
                comandoSQL.CommandText = sentenciaSQL;
                comandoSQL.CommandType = CommandType.Text;
                return comandoSQL;
            }

            catch (Exception err)
            {
                throw new Exception("Error al ejecutar comando en la base de datos.", err);
            }
        }

        public SqlCommand ObtenerComandoDeProcedimiento(String procedimientoAlmacenado)
        {
            try
            {
                SqlCommand comandoSQL = conexion.CreateCommand();
                if (transaccion != null)
                {
                    comandoSQL.Transaction = transaccion;
                }
                comandoSQL.CommandText = procedimientoAlmacenado;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                return comandoSQL;
            }

            catch (Exception err)
            {
                throw new Exception("Error al ejecutar comando en la base de datos.", err);
            }
        }


    }
}
