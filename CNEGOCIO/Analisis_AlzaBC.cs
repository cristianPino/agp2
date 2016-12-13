using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class Analisis_AlzaBC
    {
        public string add_analisis_alza(Int32 monto, string cod_financiera, Int32 id_solicitud, string fecha_carta, string fecha_termino,string fecha_otorgamiento)
        {
            return new Analisis_AlzaDAC().add_analis_alza(cod_financiera,monto,fecha_carta,fecha_termino,id_solicitud,fecha_otorgamiento);
        }

        public Analisis_Alza getAnalisis_Alza(Int32 id_solicitud)
        {
            Analisis_Alza malza = new Analisis_AlzaDAC().getAnalis_alza(id_solicitud);
            return malza;
        }
    }
}
