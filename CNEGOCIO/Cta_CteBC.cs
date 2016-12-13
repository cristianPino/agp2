using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
   public class Cta_CteBC
    {
        public List<Cuenta_Corriente> getCta_Cte(string cuenta_usuario)
        {
            List<Cuenta_Corriente> lCta_Cte = new Cta_CteDAC().getCta_Cte(cuenta_usuario);
            return lCta_Cte;
        }

        public string add_Cta_Cte(string cuenta_usuario, string numero,string banco,string tipo)
        {
            string add = new Cta_CteDAC().add_cta_cte(cuenta_usuario,numero,tipo,banco);
            return add;
        }
    }
}
