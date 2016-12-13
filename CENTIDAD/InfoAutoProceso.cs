using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class InfoAutoProceso  :InfoAuto
    {
        public int IdPaso { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public bool Estado { get; set; }
        public string DescripcionPaso { get; set; }
    }
}
