using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CatalogoWeb
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected string IdProducto { get; set; }
        protected Usuario Usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
                Usuario = (Usuario)Session["usuario"];

            try
            {
                IdProducto = Request.QueryString["Id"] != null ? Request.QueryString["id"] : "";


                if (IdProducto != "")
                {
                    Articulos articulo = new Articulos();
                    ArticulosNegocio negocio = new ArticulosNegocio();

                    articulo = (negocio.Listar(IdProducto))[0];
                    
                    lblId.Text = IdProducto;
                    lblCodigo.Text = articulo.Codigo;
                    lblNombre.Text = articulo.Nombre;
                    lblDescripcion.Text = articulo.Descripcion;
                    lblMarca.Text = articulo.Marca.ToString();
                    lblCategoria.Text = articulo.Categoria.Descripcion;
                    lblPrecio.Text = articulo.Precio.ToString();
                    imgImagen.ImageUrl = articulo.ImagenUrl;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("mensaje", 2);
                Response.Redirect("Mensaje.aspx");
                return;
            }

            FavoritosNegocio negocio = new FavoritosNegocio();
            List<Dominio.Favoritos> listaFav;
            try
            {
                listaFav = negocio.Listar(Usuario.Id);
                bool aux = new bool();

                if(listaFav.Count != 0)
                {
                    for (var i = 0; i< listaFav.Count; i++)
                    {
                        if(listaFav[i].IdArticulo == int.Parse(IdProducto))
                        {
                            aux = true;
                        }
                    }

                    if (aux)
                    {
                        Session.Add("mensaje", 8);
                        Response.Redirect("Mensaje.aspx");
                    }
                }

                negocio.Agregar( Usuario.Id, int.Parse(IdProducto));
                Session.Add("mensaje", 7);
                Response.Redirect("Mensaje.aspx", false);
            }catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}