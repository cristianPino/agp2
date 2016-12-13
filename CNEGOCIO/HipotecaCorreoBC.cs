using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class HipotecaCorreoBC
    {
        public List<HipotecaCorreo> GetHipotecaCorreos(int idCliente, int idFamilia)
        {
            return new HipotecaCorreoDAC().GetHipotecaCorreos(idCliente, idFamilia);
        }
        public void UptCorreos(HipotecaCorreo hipoteca)
        {
            new HipotecaCorreoDAC().UptCorreos(hipoteca);
        }
        public void DelCorreos(HipotecaCorreo hipoteca)
        {
            new HipotecaCorreoDAC().DelCorreos(hipoteca);
        }
    }
}
