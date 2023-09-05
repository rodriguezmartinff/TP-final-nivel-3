using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace CatalogoWeb
{
    public partial class MiMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                imgAvatar.ImageUrl = "~/Imagenes/Perfil/" + ((Usuario)Session["usuario"]).UrlImagen;
            }
            else
            {
                imgAvatar.ImageUrl = "~/Imagenes/Perfil/sinfoto.jpg";
            }
        }
    }
}