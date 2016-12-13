using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class TipoInfraccion
    {
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

    }
}
