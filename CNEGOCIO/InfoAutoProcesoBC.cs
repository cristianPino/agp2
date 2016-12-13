using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class InfoAutoProcesoBC
    {
        public List<InfoAutoProceso> Get_contenidoInformeDV(int idSolicitud)
        {
            return new InfoAutoProcesoDAC().Get_contenidoInformeDV(idSolicitud);
        }
    }
}
