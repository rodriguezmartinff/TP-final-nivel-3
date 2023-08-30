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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioactualizado"] != null)
                lblMensaje.Text = Session["usuarioactualizado"].ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }
    }
}