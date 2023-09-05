using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;


namespace CatalogoWeb
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Dominio.Favoritos> ListaFav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Usuario usuario = (Usuario)Session["Usuario"];

			try
			{
				FavoritosNegocio negocio = new FavoritosNegocio();
                ListaFav = negocio.Listar(usuario.Id);
                gvFavoritos.DataSource = ListaFav;
                gvFavoritos.DataBind();
			}
			catch (Exception ex)
			{
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
			}
        }

        protected void gvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvFavoritos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvFavoritos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                lblmensaje.Text = index.ToString();
                try
                {
                    FavoritosNegocio negocio = new FavoritosNegocio();
                    negocio.Eliminar(ListaFav[index].Id);
                    Session.Add("mensaje", "Articulo eliminado");
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
}