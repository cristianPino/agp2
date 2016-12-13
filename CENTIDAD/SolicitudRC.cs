using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class SolicitudRC
	{
		private int id_solicitud_rc;

		public int Id_solicitud_rc
		{
			get { return id_solicitud_rc; }
			set { id_solicitud_rc = value; }
		}

		private int id_solicitud;

		public int Id_solicitud
		{
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}

		private TipoSolicitudRC tipo_solicitud;

		public TipoSolicitudRC Tipo_solicitud
		{
			get { return tipo_solicitud; }
			set { tipo_solicitud = value; }
		}

		private OficinaRC oficina_rc;

		public OficinaRC Oficina_rc
		{
			get { return oficina_rc; }
			set { oficina_rc = value; }
		}

		private int nro_solicitud;

		public int Nro_solicitud
		{
			get { return nro_solicitud; }
			set { nro_solicitud = value; }
		}

		private int anio_solicitud;

		public int Anio_solicitud
		{
			get { return anio_solicitud; }
			set { anio_solicitud = value; }
		}

		private string estado_solicitud;

		public string Estado_solicitud
		{
			get { return estado_solicitud; }
			set { estado_solicitud = value; }
		}

		private string obs_solicitud;

		public string Obs_solicitud
		{
			get { return obs_solicitud; }
			set { obs_solicitud = value; }
		}

		private DateTime fecha_solicitud;

		public DateTime Fecha_solicitud
		{
			get { return fecha_solicitud; }
			set { fecha_solicitud = value; }
		}
	}
}