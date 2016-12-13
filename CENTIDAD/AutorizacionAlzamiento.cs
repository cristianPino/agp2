using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class AutorizacionAlzamiento
	{
		private int id_autorizacion;

		public int Id_autorizacion
		{
			get { return id_autorizacion; }
			set { id_autorizacion = value; }
		}

		private int id_solicitud_gar;

		public int Id_solicitud_gar
		{
			get { return id_solicitud_gar; }
			set { id_solicitud_gar = value; }
		}

		private int id_solicitud_alz;

		public int Id_solicitud_alz
		{
			get { return id_solicitud_alz; }
			set { id_solicitud_alz = value; }
		}

		private string cuenta_usuario;

		public string Cuenta_usuario
		{
			get { return cuenta_usuario; }
			set { cuenta_usuario = value; }
		}

		private DateTime fecha_autorizacion;

		public DateTime Fecha_autorizacion
		{
			get { return fecha_autorizacion; }
			set { fecha_autorizacion = value; }
		}
	}
}