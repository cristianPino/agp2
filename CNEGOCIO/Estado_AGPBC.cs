using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
	public class Estado_AGPBC
	{
		public Estado_AGP get_estado_agp(int id_solicitud)
		{
			return new Estado_AGPDAC().get_estado_agp(id_solicitud);
		}

		public string act_estado_agp(Int32 id_solicitud, string proceso_agp)
		{
			return new Estado_AGPDAC().act_estado_AGP(id_solicitud, proceso_agp);
		}

		public string act_repertorio_solicitado(int id_solicitud)
		{
			return new Estado_AGPDAC().act_repertorio_solicitado(id_solicitud);
		}
	}
}