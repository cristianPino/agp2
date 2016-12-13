using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class SolicitudCertificadoBC
	{
		public string add_solicitud_certificado(int id_solicitud, short id_sucursal, string patente)
		{
			SolicitudCertificado solicitud = new SolicitudCertificado();
			solicitud.Operacion = new OperacionBC().getoperacion(id_solicitud);
			solicitud.Sucursal = new SucursalclienteBC().getSucursal(id_sucursal);
			solicitud.Patente = patente;
			return new SolicitudCertificadoDAC().add_solicitud_certificado(solicitud);
		}

		public SolicitudCertificado get_solicitud_certificado(int id_solicitud)
		{
			return new SolicitudCertificadoDAC().get_solicitud_certificado(id_solicitud);
		}
	}
}