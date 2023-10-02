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
            Usuario usuario = null;

            if (Session["usuario"] != null){
                usuario = (Usuario)Session["usuario"];
            }
            else
            {
                Session.Add("mensaje", 2);
                Response.Redirect("Mensaje.aspx");
            }
            
            try
			{
				FavoritosNegocio negocio = new FavoritosNegocio();
                ListaFav = negocio.Listar(usuario.Id);
                if(ListaFav.Count == 0)
                {
                    Session.Add("mensaje", 6);
                    Response.Redirect("Mensaje.aspx", false);
                }
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
            string IdSeleccionado = gvFavoritos.SelectedDataKey.Value.ToString();
            Response.Redirect("Detalle.aspx?Id=" + IdSeleccionado);
        }

        protected void gvFavoritos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvFavoritos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                try
                {
                    FavoritosNegocio negocio = new FavoritosNegocio();
                    negocio.Eliminar(ListaFav[index].Id);
                    Session.Add("mensaje", 5);
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