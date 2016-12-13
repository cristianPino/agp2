using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ProgramacionGC
    {
        private Operacion id_solicitud;

        public Operacion Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string Hora;

        public string Hora1
        {
            get { return Hora; }
            set { Hora = value; }
        }
    }
}
