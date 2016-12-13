using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class MeratenenciaBC
    {
        public string add_meratenencia(Meratenencia mera)
        {
            
            return new MeratenenciaDAC().add_meratenencia(mera);
        }

        public Meratenencia getmeratenencia(Int32 id_solicitud)
        {
            return new MeratenenciaDAC().getmeratenencia(id_solicitud);
        }

    }
}
