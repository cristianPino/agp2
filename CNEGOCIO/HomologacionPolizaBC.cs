using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class HomologacionPolizaBC
    {

        public string add_homologacionpoliza(string codigo_distribuidor, string codigo, Int32 codigoTipVehDist)
        {

            string add = new HomologacionPolizaDAC().add_homologacionpoliza(codigo_distribuidor, codigo, codigoTipVehDist);
            return add;

        }
        public List<HomologacionPoliza> gethomologacionpoliza(string codigo_distribuidor)
        {
            List<HomologacionPoliza> lhomologacionpoliza = new HomologacionPolizaDAC().getHomologacionpoliza(codigo_distribuidor);
            return lhomologacionpoliza;
        }

        public HomologacionPoliza gethomologacionpolizabycodigo(string codigo_distribuidor, string codigoTipVehDist)
        {

            HomologacionPoliza add = new HomologacionPolizaDAC().getHomologacionpolizabycodigo(codigo_distribuidor, codigoTipVehDist);
            return add;

        }

    }
}
