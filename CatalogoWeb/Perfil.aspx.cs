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
    public partial class Perfil : System.Web.UI.Page
    {
        public bool Editar { get; set; }
        public string ImagenUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (Session["usuario"] == null)
            {
                Session.Add("Error", "Primero debes loguearte.");
                Response.Redirect("Error.aspx", false);
            }

            Usuario usuario = (Usuario)Session["usuario"];

            txtId.Text = usuario.Id.ToString();
            txtEmail.Text = usuario.Email;
            txtContraseña.Text = usuario.Contraseña;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtImagen.Text = usuario.UrlImagen;
            CargarImagen();

            Editar = false;
            ActivarEditar();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar = true;
            ActivarEditar();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();

                usuario.Id = int.Parse(txtId.Text);
                usuario.Email = txtEmail.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.UrlImagen = txtImagen.Text;

                negocio.Actualizar(usuario);

                Editar = false;

                Session.Remove("usuario");
                Session.Add("usuario", usuario);
                Session.Add("usuarioactualizado", "Usuario actualizado correctamente");
                Response.Redirect("Mensaje.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Editar = false;
            ActivarEditar();
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            CargarImagen();
            Editar = true;
        }

        protected void CargarImagen()
        {
            imgImagen.ImageUrl = txtImagen.Text;
            //ImagenUrl = txtImagen.Text;
        }

        protected void ActivarEditar()
        {
            txtId.Enabled = Editar;
            txtEmail.Enabled = Editar;
            txtContraseña.Enabled = Editar;
            txtNombre.Enabled = Editar;
            txtApellido.Enabled = Editar;
            txtImagen.Enabled = Editar;
        }
    }
}
