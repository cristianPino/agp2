using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class GastosInfraccionBC
    {

        public List<GastosInfraccion> Getinfraccion(Int32 id_solicitud)
        {

            List<GastosInfraccion> linfracion = new GastosInfraccionDAC().GetGastosInfraccionbysolicitud(id_solicitud);
            return linfracion;


        }

        public string add_gastosInfraccion(Int32 id_solicitud, string codigo, string observacion, Int32 monto,string fecha)
        {

            string add = new GastosInfraccionDAC().add_gastosInfraccion(id_solicitud, codigo, observacion, monto,fecha);

            return add;

        }




    }
}
