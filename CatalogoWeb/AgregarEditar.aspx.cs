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

            if (Session["usuario"] == null)
            {
				Session.Add("error", "Primero debes loguearte");
				Response.Redirect("Error.aspx");
            }

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

                string IdProducto = Request.QueryString["Id"] != null ? Request.QueryString["id"] : "";

				if(IdProducto != "")
				{
					ArticulosNegocio negocio = new ArticulosNegocio();
					Articulos articulo = new Articulos();
					articulo = negocio.Listar(IdProducto)[0];

					txtId.Text = IdProducto;
					txtCodigo.Text = articulo.Codigo;
					txtNombre.Text = articulo.Nombre;
					txtDescripcion.Text = articulo.Descripcion;
					txtImagenUrl.Text = articulo.ImagenUrl;
					txtPrecio.Text = articulo.Precio.ToString();
					ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
					ddlMarca.SelectedValue = articulo.Marca.Id.ToString();

					txtImagenUrl_TextChanged(sender, e);
				}
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
				nuevo.Id = int.Parse(txtId.Text);
				nuevo.Nombre = txtNombre.Text;
				nuevo.Codigo = txtCodigo.Text;
				nuevo.Descripcion = txtDescripcion.Text;
				nuevo.ImagenUrl = txtImagenUrl.Text;
				nuevo.Precio = Decimal.Parse(txtPrecio.Text);

				nuevo.Marca = new Marcas();
				nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

				nuevo.Categoria = new Categorias();
				nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

				if (txtId.Text == "")
					articulonegocio.Agregar(nuevo);
				else
					articulonegocio.Modificar(nuevo);

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