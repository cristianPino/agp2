using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class RepertorioBC
	{
		public int add_repertorio(string cuenta_usuario)
		{
			return new RepertorioDAC().add_repertorio(cuenta_usuario);
		}

		public string add_repertorio_operacion(int id_repertorio, int id_solicitud)
		{
			return new RepertorioDAC().add_repertorio_operacion(id_repertorio, id_solicitud);
		}
	}
}
