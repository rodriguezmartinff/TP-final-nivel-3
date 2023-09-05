using System;
using System.Collections.Generic;
using System.Linq;
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
            FavoritosNegocio negocio = new FavoritosNegocio();

            try
            {
                negocio.Agregar( Usuario.Id, int.Parse(IdProducto));
                Session.Add("mensaje", "Agregado correctamente");
                Response.Redirect("Mensaje.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}