using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class AutorizacionAlzamientoBC
	{
		public string AddAutorizacionAlzamiento(int id_solicitud_gar, int id_solicitud_alz, string cuenta_usuario)
		{
			AutorizacionAlzamiento autorizacion = new AutorizacionAlzamiento();
			autorizacion.Id_solicitud_gar = id_solicitud_gar;
			autorizacion.Id_solicitud_alz = id_solicitud_alz;
			autorizacion.Cuenta_usuario = cuenta_usuario;
			return new AutorizacionAlzamientoDAC().AddAutorizacionAlzamiento(autorizacion);
		}
	}
}