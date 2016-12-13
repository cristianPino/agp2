using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class VentaSoapBC
    {
        public VentaSoap getsoap(Int32 id_solicitud,string codigo_distribuidor,string fecha_desde)
        {

            VentaSoap mventasoap= new VentaSoapDAC().getSoap(id_solicitud, codigo_distribuidor,fecha_desde);
            return mventasoap;


        }

    }
}
