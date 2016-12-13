using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
	public class RegionBC
	{
		public string add_region(string pais, string nombre)
		{
			Region mregion = new Region();
			mregion.Nombre = nombre;
			mregion.Pais = new PaisDAC().getpais(pais);
			return new RegionDAC().add_region(mregion);
		}

		public List<Region> getregionbypais(string strcodigo)
		{
			return new RegionDAC().getregionbypais(strcodigo);
		}
	}
}