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
    public partial class Perfil : System.Web.UI.Page
    {
        public bool Editar { get; set; }
        public string ImagenUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (Session["usuario"] == null)
            {
                Session.Add("mensaje", 2);  //primero debes loguearte
                Response.Redirect("Mensaje.aspx");
            }
            Usuario usuario = new Usuario();

            usuario = (Usuario)Session["usuario"];

            txtId.Text = usuario.Id.ToString();
            txtEmail.Text = usuario.Email;
            txtContraseña.Text = usuario.Contraseña;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;

            
            ViewState["auximagen"] = usuario.UrlImagen;
            imgImagen.ImageUrl = "~/Imagenes/Perfil/" + ViewState["auximagen"] + "?v=" + DateTime.Now.Ticks.ToString();

            CargarImagen();
            
            Editar = false;
            ActivarEditar();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar = true;
            ActivarEditar();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            if (txtEmail.Text == "" || txtContraseña.Text == "")
            {
                Session.Add("mensaje", 10);
                Response.Redirect("Mensaje.aspx");
            }

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();

                usuario.Id = int.Parse(txtId.Text);
                usuario.Email = txtEmail.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                
                if(txtImagenLocal.Value != "")
                {
                    string rutaImagen = Server.MapPath("./Imagenes/Perfil/");   //ruta del servidor
                    txtImagenLocal.PostedFile.SaveAs(rutaImagen + "Perfil-" + int.Parse(txtId.Text) + ".jpg");   //guarda la imagen en la ruta del servidor
                    
                    usuario.UrlImagen = "Perfil-" + int.Parse(txtId.Text) + ".jpg";
                }
                else
                {
                    usuario.UrlImagen = (string)ViewState["auximagen"];
                }
                

                negocio.Actualizar(usuario);

                Editar = false;

                Session.Remove("usuario");
                Session.Add("usuario", usuario);
                Session.Add("mensaje", 4);  //perfil actualizado correctamente
                Response.Redirect("Mensaje.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgImagen.ImageUrl = "~/Imagenes/Perfil/" + ViewState["auximagen"];
        }

        protected void CargarImagen()
        {
            //imgImagen.ImageUrl = txtImagen.Text;
        }

        protected void ActivarEditar()
        {
            txtEmail.Enabled = Editar;
            txtContraseña.Enabled = Editar;
            txtNombre.Enabled = Editar;
            txtApellido.Enabled = Editar;
            txtImagenLocal.Disabled = !Editar;
        }


    }
}
