using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            Conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            
            //Conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            Comando = new SqlCommand();

        }

        public void SetearConsulta(string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;

        }

        public void SetearProcedure(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;
        }

        public void EjecutarLectura()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EjecutarAccion()
        {
            Comando.Connection = Conexion;

            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EjecutarAccionScalar()
        {
            Comando.Connection = Conexion;

            try
            {
                Conexion.Open();
                return int.Parse(Comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if (lector != null) { lector.Close(); }
            Conexion.Close();
        }

        public void SetearParametro(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);

        }
    }
}
