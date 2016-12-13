using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class Leasing_transferenciaBC
    {
        public List<Leasing_transferencia> getLeasingById_solicitud(Int32 id_solicitud)
        {
            List<Leasing_transferencia> lLeasing = new Leasing_transferenciaDAC().GetLeasingByIdSolicitud(id_solicitud);
            return lLeasing;
        }

        public Leasing_transferencia getLeasingById(Int32 id_solicitud)
        {
            Leasing_transferencia lLeasing = new Leasing_transferenciaDAC().GetLeasingById(id_solicitud);
            return lLeasing;
        }


        public String add_leasing(Int32 id_solicitud, string patente, Int32 n_contrato, DateTime fecha_contrato, Int32 valor_opcion, Int32 valor_cesion,Int32 n_vehiculos)
        {
            String add = new Leasing_transferenciaDAC().add_leasing(id_solicitud, patente, fecha_contrato, n_contrato, valor_cesion, valor_opcion,n_vehiculos);

            return add;
        }

        public Leasing_transferencia getLeasing(string patente)
        {
            return new Leasing_transferenciaDAC().getLeasing(patente);
        }
    }
}
