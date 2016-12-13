using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class SolicitudRCBC
	{
		public string add_SolicitudRC(int id_solicitud_rc, int id_solicitud, int cod_solicrc, int codigo_oficina_rc, int nro_solicitud, int anio_solicitud, string estado_solicitud, string obs_solicitud, DateTime fecha_solicitud)
		{
			SolicitudRC solicitud = new SolicitudRC();
			solicitud.Id_solicitud_rc = id_solicitud_rc;
			solicitud.Id_solicitud = id_solicitud;
			solicitud.Tipo_solicitud = new TipoSolicitudRCDAC().getTipoSolicitudRC(cod_solicrc);
			solicitud.Oficina_rc = new OficinaRCDAC().get_OficinaRC(codigo_oficina_rc);
			solicitud.Nro_solicitud = nro_solicitud;
			solicitud.Anio_solicitud = anio_solicitud;
			solicitud.Estado_solicitud = estado_solicitud;
			solicitud.Obs_solicitud = obs_solicitud;
			solicitud.Fecha_solicitud = fecha_solicitud;
			return new SolicitudRCDAC().add_SolicitudRC(solicitud);
		}

		public List<SolicitudRC> get_SolicitudRC_Operacion(int id_solicitud)
		{
			return new SolicitudRCDAC().get_SolicitudRC_Operacion(id_solicitud);
		}
	}
}