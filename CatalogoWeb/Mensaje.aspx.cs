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
                case 2:
                    lblMensaje.Text = "Primero debes logearte";
                    break;
                case 3:
                    lblMensaje.Text = "Sin permiso de administrador.";
                    break;
                case 4:
                    lblMensaje.Text = "Perfil actualizado correctamente";
                    break;
                case 5:
                    lblMensaje.Text = "Favorito eliminado.";
                    break;
                case 6:
                    lblMensaje.Text = "Aún no has agregado artículos a tu lista de favoritos.";
                    break;
                case 7:
                    lblMensaje.Text = "Artículo agregado correctamente.";
                    break;
                case 8:
                    lblMensaje.Text = "El artículo ya está en tu lista de favoritos.";
                    break;
                case 9:
                    lblMensaje.Text = "El email ingresado ya se encuentra registrado.";
                    break;
                case 10:
                    lblMensaje.Text = "Campos incompletos";
                    break;
                default:
                    //lblMensaje.Text = Session["mensaje"].ToString();
                    break;
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Session["mensaje"])
            {
                case 2: //primero debes loguearte
                    Response.Redirect("Login.aspx");
                    break;
                case 1: //usuario agregado corectamente
                    Response.Redirect("Login.aspx");
                    break;
                case 4:
                    Response.Redirect("Perfil.aspx");
                    break;
                case 5:
                    Response.Redirect("Favoritos.aspx");
                    break;
                case 7: //articulo agregado correctamente a favoritos
                    Response.Redirect("Favoritos.aspx");
                    break;
                case 8: //articulo ya agregado
                    Response.Redirect("Favoritos.aspx");
                    break;
                case 9: //email no disponible
                    Response.Redirect("Registrarse.aspx");
                    break;
                case 10:    //falta completar campos en perfil
                    Response.Redirect("Perfil.aspx"); 
                    break;
                default:
                    Response.Redirect("Default.aspx");
                    break;
            }
        }
    }
}