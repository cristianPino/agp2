using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO {
	public class TipoSolicitudRCBC {

		public string addTipoSolicitudRC(int codigo, string descripcion, string correos) {
			TipoSolicitudRC solicitud = new TipoSolicitudRC();
			solicitud.CodSolicRC = codigo;
			solicitud.DescSolicRC = descripcion;
			solicitud.ListaCorreos = correos;
			return new CACCESO.TipoSolicitudRCDAC().addTipoSolicitudRC(solicitud);
		}

		public TipoSolicitudRC getTipoSolicitudRC(int codigo) {
			return new CACCESO.TipoSolicitudRCDAC().getTipoSolicitudRC(codigo);
		}

		public List<TipoSolicitudRC> getTipoSolicitudRC() {
			return new CACCESO.TipoSolicitudRCDAC().getTipoSolicitudRC();
		}

		public List<TipoSolicitudRCProducto> getTipoSolicitudRC_by_TipoOperacion(string codigo) {
			return new CACCESO.TipoSolicitudRCDAC().getTipoSolicitudRC_by_TipoOperacion(codigo);
		}
	}
}