using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class ProgramacionGCBC
    {

        public string add_programacioGC(Int32 id_solicitud, DateTime fecha, string hora)
        {

            

            string add = new programacionGCDAC().add_programacionGC(id_solicitud,fecha,hora);

            return add;
        }
    }
}
