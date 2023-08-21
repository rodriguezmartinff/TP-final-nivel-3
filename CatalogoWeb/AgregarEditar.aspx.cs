using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using static System.Net.WebRequestMethods;

namespace CatalogoWeb
{
    public partial class AgregarEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			txtId.Enabled = false;

			if (IsPostBack)
				return;

			try
			{
				CategoriaNegocio categorianegocio = new CategoriaNegocio();
				ddlCategoria.DataSource = categorianegocio.listar();
				ddlCategoria.DataValueField = "Id";
				ddlCategoria.DataTextField = "Descripcion";
				ddlCategoria.DataBind();

				MarcaNegocio marcanegocio = new MarcaNegocio();
				ddlMarca.DataSource = marcanegocio.listar();
				ddlMarca.DataValueField = "Id";
				ddlMarca.DataTextField = "Descripcion";
				ddlMarca.DataBind();
			}
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx");
			}
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
			try
			{
				imgArticulo.ImageUrl = txtImagenUrl.Text;
            }
            catch (Exception)
            {
				//imgArticulo.ImageUrl = "https://wintechnology.co/wp-content/uploads/2021/11/imagen-no-disponible.jpg";
			}
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
			try
			{
				ArticulosNegocio articulonegocio = new ArticulosNegocio();
				Articulos nuevo = new Articulos();
				nuevo.Nombre = txtNombre.Text;
				nuevo.Codigo = txtCodigo.Text;
				nuevo.Descripcion = txtDescripcion.Text;
				nuevo.ImagenUrl = txtImagenUrl.Text;
				nuevo.Precio = Decimal.Parse(txtPrecio.Text);

				nuevo.Marca = new Marcas();
				nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

				nuevo.Categoria = new Categorias();
				nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

				articulonegocio.Agregar(nuevo);
				Response.Redirect("ListaArticulos.aspx", false);

			}
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx");
			}
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
			Response.Redirect("ListaArticulos.aspx");
        }
    }
}