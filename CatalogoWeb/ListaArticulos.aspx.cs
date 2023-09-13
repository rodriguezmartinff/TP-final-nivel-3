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
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = cbFiltroAvanzado.Checked;

            //if (IsPostBack)
            //    return;

            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                Session.Add("ListaArticulos", negocio.Listar());

                if (Session["usuario"] == null)
                {
                    gvArticulos.DataSource = Session["ListaArticulos"];
                    gvArticulos.DataBind();
                }
                else
                {
                    gvArticulosLogin.DataSource = Session["ListaArticulos"];
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

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                gvArticulos.DataSource = ((List<Articulos>)Session["ListaArticulos"]).FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                gvArticulos.DataBind();
            }
            else
            {
                gvArticulosLogin.DataSource = ((List<Articulos>)Session["ListaArticulos"]).FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                gvArticulosLogin.DataBind();
            }
        }

        protected void cbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = cbFiltroAvanzado.Checked;
            txtBuscar.Enabled = !FiltroAvanzado;
            ddlCampo_SelectedIndexChanged(sender, e);
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() != "Precio")
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Empieza con");
            }
            else
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Mayor a");
            }
        }

        protected void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();

                if (Session["usuario"] == null)
                {
                    gvArticulos.DataSource = negocio.Filtrar(ddlCampo.SelectedValue.ToString(),
                    ddlCriterio.SelectedValue.ToString(), txtFiltroAvanzado.Text);
                    gvArticulos.DataBind();
                }
                else
                {
                    gvArticulosLogin.DataSource = negocio.Filtrar(ddlCampo.SelectedValue.ToString(),
                    ddlCriterio.SelectedValue.ToString(), txtFiltroAvanzado.Text);
                    gvArticulosLogin.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}