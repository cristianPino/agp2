using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class ComportamientoEstadoBC
    {
        public List<ComportamientoEstado> getcomportamiento(Int32 codigo_estado)
        {
            return new ComportamientoEstadoDAC().getComportamiento(codigo_estado);
        }

        public string add_comportamienti(Int32 codigo_estado, Int32 origen, Int32 estado_final)
        {
            return new ComportamientoEstadoDAC().add_comportamiento(codigo_estado,origen,estado_final);
        }
        public string del_comportamiento(Int32 id_comportamiento)
        {
            return new ComportamientoEstadoDAC().del_comportamiento(id_comportamiento);
        }
        public List<ComportamientoEstado> GetComportamientoFlujo(int codigoEstado, int codigoOrigen)
        {
            return new ComportamientoEstadoDAC().GetComportamientoFlujo(codigoEstado, codigoOrigen);
        }
        public ComportamientoEstado GetEstadoOrigen(int idSolicitud)
        {
            return new ComportamientoEstadoDAC().GetEstadoOrigen(idSolicitud);
        }
        public bool ValidacionComportamiento(int estadoActual, int siguienteEstado)
        {
            return new ComportamientoEstadoDAC().ValidacionComportamiento(estadoActual, siguienteEstado);
        }

    }
}
