using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class HipotecaOperacionEjecutivoBC
    {
        public List<HipotecaOperacionEjecutivo> Get_hipoteca_operacion_ejecutivobyOperacion(int idSolicitud)
        {
            return new HipotecaOperacionEjecutivoDAC().Get_hipoteca_operacion_ejecutivobyOperacion(idSolicitud);
        }
        public void DelEjecutivoHipoteca(HipotecaOperacionEjecutivo hip)
        {
            new HipotecaOperacionEjecutivoDAC().DelEjecutivoHipoteca(hip);
        }
        public string AddEjecutivoHipoteca(HipotecaOperacionEjecutivo hip)
        {
            return new HipotecaOperacionEjecutivoDAC().AddEjecutivoHipoteca(hip);
        }

    }
}
