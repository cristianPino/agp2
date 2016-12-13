using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public  class ActividadDeOrdenTrabajo
    {
        public int IdActividad { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public string Url { get; set; }
        public int Sla { get; set; }
    }
}
