using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
   public class Replace_garantiaBC
    {
        public List<Replace_garantia> getreplace()
        {
            List<Replace_garantia> lCta_Cte = new Replace_GarantiaDAC().getReplace();
            return lCta_Cte;
        }


    }
}
