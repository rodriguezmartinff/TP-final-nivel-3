using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> Listar(string id = "")
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, IdMarca, C.Descripcion Categoria, IdCategoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id ";

            if (id != "")
                consulta += "and A.Id = " + id;

            try
            {
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["imagenurl"];
                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
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

        public void Agregar(Articulos Nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)" +
                    "values( @Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @url, @Precio)");
                Datos.SetearParametro("@Codigo", Nuevo.Codigo);
                Datos.SetearParametro("@Nombre", Nuevo.Nombre);
                Datos.SetearParametro("@Descripcion", Nuevo.Descripcion);
                Datos.SetearParametro("@IdMarca", Nuevo.Marca.Id);
                Datos.SetearParametro("@IdCategoria", Nuevo.Categoria.Id);
                Datos.SetearParametro("@url", Nuevo.ImagenUrl);
                Datos.SetearParametro("@Precio", Nuevo.Precio);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public void Modificar(Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, " +
                    "Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, " +
                    "ImagenUrl = @url, Precio = @precio where Id = @id");
                datos.SetearParametro("@codigo", articulo.Codigo);
                datos.SetearParametro("@nombre", articulo.Nombre);
                datos.SetearParametro("@descripcion", articulo.Descripcion);
                datos.SetearParametro("@url", articulo.ImagenUrl);
                datos.SetearParametro("@idmarca", articulo.Marca.Id);
                datos.SetearParametro("@idcategoria", articulo.Categoria.Id);
                datos.SetearParametro("@id", articulo.Id);
                datos.SetearParametro("@precio", articulo.Precio);

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

        public void Eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id");
                datos.SetearParametro("@Id", Id);

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

        public List<Articulos> Filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, " +
                    "M.Descripcion Marca, C.Descripcion Categoria, IdMarca, IdCategoria, Precio " +
                    "from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id " +
                    "and C.Id = A.IdCategoria and ";

                if (campo == "Precio")
                {
                    decimal d;
                    try
                    {
                        d = decimal.Parse(filtro);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    consulta += "A.Precio ";

                    switch (criterio)
                    {
                        case "Mayor a":
                            {
                                consulta += "> @filtro";
                                break;
                            }
                        case "Menor a":
                            {
                                consulta += "< @filtro";
                                break;
                            }
                        default:
                            {
                                consulta += "= @filtro";
                                break;
                            }
                    }
                    datos.SetearParametro("@filtro", d);
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "A.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "C.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;

                    }
                }

                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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
    }
}
