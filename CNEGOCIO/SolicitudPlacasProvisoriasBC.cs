using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class SolicitudPlacasProvisoriasBC
	{
		public string add_solicitud_placas_provisorias(int id_solicitud, short id_sucursal, string patente, double rut)
		{
			SolicitudPlacasProvisorias solicitud = new SolicitudPlacasProvisorias();
			solicitud.Operacion = new OperacionBC().getoperacion(id_solicitud);
			solicitud.Sucursal = new SucursalclienteBC().getSucursal(id_sucursal);
			solicitud.Patente = patente;
			solicitud.Adquirente = new PersonaDAC().getpersonabyrut(rut);
			return new SolicitudPlacasProvisioriasDAC().add_solicitud_placas_provisorias(solicitud);
		}

		public SolicitudPlacasProvisorias get_solicitud_placas_provisorias(int id_solicitud)
		{
			return new SolicitudPlacasProvisioriasDAC().get_solicitud_placas_provisorias(id_solicitud);
		}

		public SolicitudPlacasProvisorias get_solicitud_placas_provisorias(string patente)
		{
			return new SolicitudPlacasProvisioriasDAC().get_solicitud_placas_provisorias(patente);
		}
	}
}
