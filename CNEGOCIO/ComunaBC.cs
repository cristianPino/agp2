using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
	public class ComunaBC
	{
		public string add_comuna(Int16 id_ciudad, string nombre)
		{
			Comuna mcomuna = new Comuna();
			mcomuna.Nombre = nombre;
			mcomuna.Ciudad = new CiudadDAC().getciudad(id_ciudad);
			return new ComunaDAC().add_Comuna(mcomuna);
		}

		public List<Comuna> getComunabyciudad(Int16 id_ciudad)
		{
			return new ComunaDAC().getComunabyciudad(id_ciudad);
		}

		public List<Comuna> getComunabyregion(Int16 id_region)
		{
			return new ComunaDAC().getComunabyregion(id_region);
		}

		public Comuna getComuna(Int16 id_comuna)
		{
			return new ComunaDAC().getComuna(id_comuna);
		}
	}
}