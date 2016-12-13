using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class OficinaRCBC
	{

		public string add_OficinaRC(int codigo, string descripcion, short id_region)
		{
			OficinaRC oficina = new OficinaRC();
			oficina.Codigo_oficina_rc = codigo;
			oficina.Descripcion_oficina_rc = descripcion;
			oficina.Region_oficina_rc = new RegionDAC().getregion(id_region);
			return new OficinaRCDAC().add_OficinaRC(oficina);
		}

		public OficinaRC get_OficinaRC(int codigo)
		{
			return new OficinaRCDAC().get_OficinaRC(codigo);
		}

		public List<OficinaRC> get_OficinasRC(int id_region)
		{
			return new OficinaRCDAC().get_OficinasRC(id_region);
		}
	}
}
