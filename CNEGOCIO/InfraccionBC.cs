using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class InfraccionBC
    {
        public string add_infraccion(Int32 id_solicitud, string patente, Int32 rut,string sucursal_origen)
        {

            string add = new InfraccionDAC().add_Infraccion(id_solicitud,patente,rut,sucursal_origen);

            return add;

        }


        public Infraccion Getinfraccionbypatente(Int32 id_cliente, string patente, string tipo_operacion)
        {

			Infraccion minfraccion = new InfraccionDAC().Getinfraccionbypatente(id_cliente, patente, tipo_operacion);
            return minfraccion;


        }

        public Infraccion GetinfraccionbyIdSolicitud(Int32 id_solicitud)
        {

            Infraccion minfracion = new InfraccionDAC().GetInfraccionbyIdSolicitud(id_solicitud);
            return minfracion;


        }

       




    }
}
