using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class DatoContacto
    {
        private Operacion id_solicitud;

        public Operacion Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }

        private Int32 id_referencia;

        public Int32 Id_referencia
        {
            get { return id_referencia; }
            set { id_referencia = value; }
        }


        private string referencia;

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

      

        
    }
}
