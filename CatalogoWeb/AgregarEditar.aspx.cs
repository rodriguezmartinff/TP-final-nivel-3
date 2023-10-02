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
		public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			txtId.Enabled = false;
			ConfirmaEliminacion = false;

			if (IsPostBack)
				return;

			if (Session["usuario"] == null)
			{
				Session.Add("mensaje", 2);	//primero debes loguearte
				Response.Redirect("Mensaje.aspx");
			}else if (((Dominio.Usuario)Session["usuario"]).tipoUsuario != TipoUsuario.ADMIN)
			{
				Session.Add("mensaje", 3);	//sin permiso de administrador
                Response.Redirect("Mensaje.aspx");
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
			Page.Validate();
			if (!Page.IsValid)
				return;

			decimal precio;
			try
			{
				if (txtPrecio.Text != "")
					precio = decimal.Parse(txtPrecio.Text);
				else
					precio = 0;
			}
			catch (Exception)
			{
				lblPrecio.Text = "Formato incorrecto";
				return;
			}

			try
			{
				ArticulosNegocio articulonegocio = new ArticulosNegocio();
				Articulos nuevo = new Articulos();
				nuevo.Id = txtId.Text != "" ? int.Parse(txtId.Text) : 0;
				nuevo.Nombre = txtNombre.Text;
				nuevo.Codigo = txtCodigo.Text;
				nuevo.Descripcion = txtDescripcion.Text;
				nuevo.ImagenUrl = txtImagenUrl.Text;
				nuevo.Precio = precio;

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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
			ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
			try
			{
				if (cbConfirmaEliminacion.Checked)
				{
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    negocio.Eliminar(int.Parse(txtId.Text));
					Response.Redirect("ListaArticulos.aspx", false);
                }
			}
			catch (Exception ex)
			{
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}