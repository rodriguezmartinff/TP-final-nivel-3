using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario Usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select Id, nombre, apellido, UrlImagenPerfil, admin from USERS where email = @email " +
                    "and pass = @pass");
                datos.SetearParametro("@email", Usuario.Email);
                datos.SetearParametro("@pass", Usuario.Contraseña);

                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario.Id = (int)datos.Lector["Id"];
                    Usuario.tipoUsuario = (bool)datos.Lector["admin"] == true ? TipoUsuario.ADMIN :TipoUsuario.NORMAL;
                    Usuario.UrlImagen = !(datos.Lector["UrlImagenPerfil"] is DBNull) ? (string)datos.Lector["UrlImagenPerfil"] : "";
                    Usuario.Nombre = !(datos.Lector["nombre"] is DBNull) ? (string)datos.Lector["nombre"] : "";
                    Usuario.Apellido = !(datos.Lector["apellido"] is DBNull) ? (string)datos.Lector["apellido"] : "";
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int AgregarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.SetearProcedure("insertarNuevo");
                //datos.SetearParametro("@usuario", nuevo.NombreUsuario);
                //datos.SetearParametro("@contraseña", nuevo.Contraseña);

                //return datos.EjecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return 0;
        }

        public void Actualizar(Usuario usuario)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.SetearConsulta("update USUARIO set Imagen = @imagen, FechaNacimiento = @fecha where Id = @id");
                //datos.SetearParametro("@imagen", usuario.Imagen);
                //datos.SetearParametro("@id", usuario.Id);
                //datos.SetearParametro("@fecha", usuario.Fecha);
                //datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();

            }
        }
    }
}
