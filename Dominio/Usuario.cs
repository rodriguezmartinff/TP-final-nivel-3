using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 0,
        ADMIN = 1,
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //public string Contraseña
        //{
        //    get { return contraseña; }
        //    set
        //    {
        //        if (value != "")
        //        {
        //            contraseña = value;
        //        }
        //        else
        //        {
        //            throw new Exception("contraseña vacia en el dominio...");
        //        }
        //    }
        //}

        public TipoUsuario tipoUsuario { get; set; }
        public string UrlImagen { get; set; }
        public Usuario(string email ="", string pass="", bool admin=false)
        {
            Email = email;
            Contraseña = pass;
            tipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
