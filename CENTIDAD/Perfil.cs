using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public class Perfil
    {
        private string codigoperfil;
        private string descripcion;
        private string url_inicio;

        public  string Codigoperfil
        {
            get { return codigoperfil; }
            set { codigoperfil = value; }
        }
        

        public  string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        

        public string Url_inicio
        {
            get { return url_inicio; }
            set { url_inicio = value; }
        }

    }
}
