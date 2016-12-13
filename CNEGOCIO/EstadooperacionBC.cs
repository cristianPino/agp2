using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;
namespace CNEGOCIO
{
    public class EstadooperacionBC
    {

        public List<EstadoOperacion> getEstadoByoperacion(int id_solicitud, string cuenta_usuario)
        {
            List<EstadoOperacion> lEstadooperacion = new EstadooperacionDAC().getEstadoByoperacion(id_solicitud, cuenta_usuario);
            return lEstadooperacion;
        }

        public string add_Estadooperacion(int id_solicitud, Int32 codigo_estado, string observacion, string cuenta_usuario)
        {
            string add = new EstadooperacionDAC().add_Estadooperacion(id_solicitud, codigo_estado, observacion, cuenta_usuario);
            return add;
        }
        public string add_EstadooperacionCliente(int id_solicitud, Int32 codigo_estado, string observacion, string cuenta_usuario)
        {
            string add = new EstadooperacionDAC().add_Estadooperacioncliente(id_solicitud, codigo_estado, observacion, cuenta_usuario);
            return add;
        }

        public string add_estado_orden(int id_solicitud, Int32 orden, string codigo, string observacion, string cuenta_usuario)
        {
            string add = new EstadooperacionDAC().add_estado_orden(id_solicitud, orden, codigo, observacion, cuenta_usuario);
            return add;
        }

        public EstadoOperacion getUltimoEstadoByIdoperacion(int id_solicitud)
        {
            return new EstadooperacionDAC().getUltimoEstadoByIdoperacion(id_solicitud);
        }

        public string update_EstadoOperacionOrdenSiguiente(int id_solicitud, string codigo, string observacion, string cuenta_usuario)
        {
            return new EstadooperacionDAC().update_EstadoOperacionOrdenSiguiente(id_solicitud, codigo, observacion, cuenta_usuario);
        }

        public EstadoOperacion getEstadobycodigoestado(int id_solicitud, int codigo_estado)
        {
            return new EstadooperacionDAC().getEstadobyCodigoestado(id_solicitud, codigo_estado);
        }


        public string add_estado_patente(int id_solicitud, string patente, string cuenta_usuario)
        {
            string add = new EstadooperacionDAC().add_estado_patente(id_solicitud, patente, cuenta_usuario);
            return add;
        }

        public string add_ActEstadooperacion(int id_solicitud, Int32 codigo_estado, string observacion, string fecha)
        {
            string add = new EstadooperacionDAC().add_actEstadooperacion(id_solicitud, codigo_estado, observacion, fecha);
            return add;
        }

        public string add_delEstadooperacion(int id_solicitud, Int32 codigo_estado)
        {
            string add = new EstadooperacionDAC().add_delEstadooperacion(id_solicitud, codigo_estado);
            return add;
        }



        public EstadoOperacion getEstadobyorden(int id_solicitud, int orden)
        {
            return new EstadooperacionDAC().getEstadobyorden(id_solicitud, orden);
        }

        public EstadoOperacion getEstadobyordenNomina(int folio, int orden,int id_nomina)
        {
            return new EstadooperacionDAC().getEstadobyordenNomina(folio, orden, id_nomina);
        }

    }
}