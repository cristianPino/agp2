using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
   public  class OpcionMenu
    {
        private string codigoopcionmenu;
        private string descripcion;
        private string estado;
        private string url;
        private int orden;
        private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        } 

        public string Codigoopcionmenu
        {
            get { return codigoopcionmenu; }
            set { codigoopcionmenu = value; }
        }
        

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        

        public  string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        

        public  string Url
        {
            get { return url; }
            set { url = value; }
        }
        public string UrlManual { get; set;  }

        public  int Orden
        {
            get { return orden; }
            set { orden = value; }
        }

    }
}
