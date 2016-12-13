using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class ControlGestionBC
    {
        public string add_controlgestion(Int32 id_solicitud, Int32 rut, Int32 id_producto_cliente,Int32 total_gestion,DateTime fecha_gestion,Int32 numero_cuotas, string numero_operacion,Int32 id_sucursal, string observacion, Int32 id_forma_pago, Int32 rut_vendedor,string patente, Int32 monto_final)
        {

            string add = new ControlGestionDAC().add_controlgestion(id_solicitud,rut,id_producto_cliente,total_gestion,fecha_gestion,numero_cuotas,numero_operacion,id_sucursal,observacion,id_forma_pago,rut_vendedor,patente,monto_final);

            return add;

        }


        public Control_gestion getcontrolgestionbysolicitud(Int32 id_solicitud)
        {

            Control_gestion mcontrolgestion= new ControlGestionDAC().getcontrolgestion(id_solicitud);
            return mcontrolgestion;


        }
    }
}
