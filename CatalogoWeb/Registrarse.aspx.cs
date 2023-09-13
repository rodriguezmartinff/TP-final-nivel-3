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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            if(txtPass.Text != txtRepPass.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden";
                return;
            }

            if(txtEmail.Text == "" || txtPass.Text == "" || txtRepPass.Text == "")
            {
                lblMensaje.Text = "Campos incompletos";
                return;
            }

            try
            {
                Usuario nuevo = new Usuario();
                nuevo.Email = txtEmail.Text;
                nuevo.Contraseña = txtPass.Text;
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.AgregarNuevo(nuevo);

                Session.Add("mensaje", 1);  //usuario generado correctamente
                Response.Redirect("Mensaje.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}