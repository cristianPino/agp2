using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
	public class CorreoBC
	{
		public List<Correo> getcorreos(int rut)
		{
			return new CorreoDAC().getcorreo(rut);
		}

		public string add_correos(int rut, string correo, int id_correo)
		{
			return new CorreoDAC().add_correo(correo, rut, id_correo);
		}

		public string actu_checkCorreo(int id_correo, string check)
		{
			return new CorreoDAC().act_check(id_correo, check);
		}

		public Correo getCorreoPorDefecto(int rut)
		{
			return new CorreoDAC().getCorreoPorDefecto(rut);
		}
	}
}