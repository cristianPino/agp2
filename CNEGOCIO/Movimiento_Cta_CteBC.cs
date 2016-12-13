using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class Movimiento_Cta_CteBC
    {
        public List<Movimiento_Cta_Cte> getCta_Cte(string cuenta_usuario)
        {
            List<Movimiento_Cta_Cte> lCta_Cte = new Movimiento_Cta_CteDAC().getCta_Cte(cuenta_usuario);
            return lCta_Cte;
        }

        public string add_Cta_Cte(Int32 id_cta_cte, Int32 monto, string tipo_movimiento,DateTime fecha_hora,string usuario_movimiento)
        {
            string add = new Movimiento_Cta_CteDAC().add_mvimiento_cta(id_cta_cte,monto,fecha_hora,tipo_movimiento,usuario_movimiento);
            return add;
        }

    }
}
