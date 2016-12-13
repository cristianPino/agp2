using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class ContratosBC
    {
        public List<Contratos> getcontratos(Int32 id_solicitud)
        {
            List<Contratos> lcontratos = new ContratosDAC().getcontratos(id_solicitud);
            return lcontratos;
        }

        public List<Contratos> getcontratosbycliente(Int32 id_solicitud)
        {
            List<Contratos> lcontratos = new ContratosDAC().getcontratosbycliente(id_solicitud);
            return lcontratos;
        }
    }
}
