using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class EstadotipooperacionBC
    {
        public List<EstadoTipoOperacion> getEstadoByTipooperacion(string codigo)
        {
            List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionDAC().getEstadoByTipooperacion(codigo);
            return lEstadotipooperacion;
        }

        public List<EstadoTipoOperacion> getEstadoByTipooperacionCliente(string codigo)
        {
            List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionDAC().getEstadoByTipooperacionCliente(codigo);
            return lEstadotipooperacion;
        }

		public List<EstadoTipoOperacion> getEstadoByFamilia(int id_familia)
		{
			return new EstadotipooperacionDAC().getEstadoByFamilia(id_familia);
		}

        public List<EstadoTipoOperacion> getEstadoByFamiliaByGrupo(int id_familia, int id_grupo)
        {
            return new EstadotipooperacionDAC().getEstadoByFamiliaByGrupo(id_familia,id_grupo);
        }

        public string add_Estadotipooperacion(Int32 codigo_estado, Int16 id_familia, string descripcion, string correo_cliente, string correo_empresa, Int32 orden,string cliente_estado,string llamada, string envia_adquiriente,int dias_primer_a, 
            int dias_ultimo_a, int caducidad_estado, int contador_estado, int id_documento,string lista_correo,Int32 id_grupo, bool estado_manual)
        {
            string add = new EstadotipooperacionDAC().add_Estadotipooperacion(codigo_estado,id_familia, descripcion,correo_cliente,correo_empresa,orden,cliente_estado,llamada,envia_adquiriente,dias_primer_a,dias_ultimo_a,caducidad_estado,contador_estado,id_documento,lista_correo,id_grupo, estado_manual);
            return add;
        }

        public EstadoTipoOperacion getestadobycodigoestado(Int32 codigo_estado)
        {
            EstadoTipoOperacion mestado = new EstadotipooperacionDAC().getEstadoBycodigo(codigo_estado);
            return mestado;
        }

        public EstadoTipoOperacion getultimoestado(Int32 id_solicitud)
        {
            EstadoTipoOperacion mestado = new EstadotipooperacionDAC().GETULTIMOESTADO(id_solicitud);
            return mestado;
        }
    }
}
