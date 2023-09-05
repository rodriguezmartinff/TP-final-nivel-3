using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class FavoritosNegocio
    {
        public List<Favoritos> Listar(int IdUser)
        {
            List<Favoritos> lista = new List<Favoritos>();
            AccesoDatos datos = new AccesoDatos();
            string consulta = "select Codigo, Nombre, Descripcion, F.Id, IdArticulo " +
                "from ARTICULOS A, FAVORITOS F " +
                "where A.Id = F.IdArticulo and F.IdUser = " + IdUser;

            try
            {
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Favoritos aux = new Favoritos();
                    aux.IdUser = IdUser;
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
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
        public void Eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta = "delete from FAVORITOS where Id = " + Id;

            try
            {
                datos.SetearConsulta(consulta);
                datos.EjecutarAccion();
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

        public void Agregar(int IdUser, int IdArt)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.SetearConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@iduser, @idarticulo)");
                datos.SetearParametro("@iduser", IdUser);
                datos.SetearParametro("@idarticulo", IdArt);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
