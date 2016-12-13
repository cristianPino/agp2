using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO {
	public class TipoSolicitudRCProductoBC {
		public string addTipoSolicitudRC_TipoOperacion(string codigo, Int32 cod_solicrc) {
			return new TipoSolicitudRCProductoDAC().addTipoSolicitudRC_TipoOperacion(codigo, cod_solicrc);
		}

		public string delTipoSolicitudRC_TipoOperacion(Int32 id) {
			return new TipoSolicitudRCProductoDAC().delTipoSolicitudRC_TipoOperacion(id);
		}

		public List<TipoSolicitudRCProducto> getTipoSolicitudRC_by_TipoOperacion(string codigo)
		{
			return new TipoSolicitudRCProductoDAC().getTipoSolicitudRC_by_TipoOperacion(codigo);
		}
	}
}