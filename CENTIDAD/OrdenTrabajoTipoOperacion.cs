using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
     public class OrdenTrabajoTipoOperacion
    {
         public int IdOrdenTrabajoTipoOperacion { get; set; }
         public TipoOperacion TipoOperacion { get; set; }
         public OrdenTrabajo OrdenTrabajo { get; set; }
         public bool Ok { get; set; }
         public int IdSolicitud { get; set; }
    }
}
