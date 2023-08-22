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
    public partial class ListaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                if (Session["usuario"] == null)
                {
                    gvArticulos.DataSource = negocio.Listar();
                    gvArticulos.DataBind();
                }
                else
                {
                    gvArticulosLogin.DataSource = negocio.Listar();
                    gvArticulosLogin.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdSeleccionado = gvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Detalle.aspx?Id=" + IdSeleccionado);
        }

        protected void gvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvArticulos.PageIndex = e.NewPageIndex;
            gvArticulos.DataBind();
        }

        protected void gvArticulosLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdSeleccionado = gvArticulosLogin.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarEditar.aspx?Id=" + IdSeleccionado);
        }

        protected void gvArticulosLogin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvArticulosLogin.PageIndex = e.NewPageIndex;
            gvArticulosLogin.DataBind();
        }
    }
}