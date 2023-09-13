using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Mensaje : System.Web.UI.Page
    {
        private int codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Session["mensaje"])
            {
                case 1:
                    lblMensaje.Text = "Perfil agregado correctamente.";
                    break;
                default:
                    lblMensaje.Text = Session["mensaje"].ToString();
                    break;
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Session["mensaje"])
            {
                case "Primero debes logearte":
                    Response.Redirect("Login.aspx");
                    break;
                case 1: //usuario agregado corectamente
                    Response.Redirect("Login.aspx");
                    break;
                default:
                    Response.Redirect("Default.aspx");
                    break;
            }
        }
    }
}