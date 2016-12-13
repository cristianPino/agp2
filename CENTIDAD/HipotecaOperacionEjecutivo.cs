using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class HipotecaOperacionEjecutivo     : EjecutivoHipotecario
    {
        public int IdHipotecaOperacionEjecutivo { set; get; }
        public int IdSolicitud { get; set; }
    }
}
