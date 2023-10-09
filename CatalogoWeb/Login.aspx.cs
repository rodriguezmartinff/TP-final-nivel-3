using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            if(txtEmail.Text == "" || txtPass.Text == "")
            {
                lblMensaje.Text = "campos vacios.";
                return;
            }

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();

                usuario.Email = txtEmail.Text;
                usuario.Contraseña = txtPass.Text;

                if(negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrecto";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}