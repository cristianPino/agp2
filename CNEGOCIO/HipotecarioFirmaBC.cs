using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public  class HipotecarioFirmaBC
    {
        public List<HipotecarioFirma> GetHipotecarioFirma(int idSolicitud)
        {
            return new HipotecarioFirmaDAC().GetHipotecarioFirma(idSolicitud);
        }

        public void AddHipotecarioFirma(HipotecarioFirma h)
        {
          new  HipotecarioFirmaDAC().AddHipotecarioFirma(h); 
        }
    }
}
