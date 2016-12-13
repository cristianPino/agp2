using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class DistribuidorpolizaBC
    {
        public List<DistribuidorPoliza> getalldistribuidorpoliza(string strcodigo)
        {
            List<DistribuidorPoliza> lDistribuidorpoliza = new DistribuidorpolizaDAC().getallDistribuidorpoliza(strcodigo);
            return lDistribuidorpoliza;

        }

        public string add_distribuidorpoliza(string codigo, string nombre)
        {

            DistribuidorPoliza mdistribuidorpoliza = new DistribuidorPoliza();

            mdistribuidorpoliza.Codigo = codigo;
            mdistribuidorpoliza.Nombre = nombre;

            string distribuidorpoliza = new DistribuidorpolizaDAC().add_distribuidorpoliza(mdistribuidorpoliza);



            return distribuidorpoliza;

        }



    }
}
