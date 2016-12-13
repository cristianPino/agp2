using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class TipoMonedaBC
	{
		public List<TipoMoneda> GetTipoMonedaTodas()
		{
			return new TipoMonedaDAC().GetTipoMonedaTodas();
		}

		public TipoMoneda GetTipoMoneda(string cod_moneda)
		{
			return new TipoMonedaDAC().GetTipoMoneda(cod_moneda);
		}
	}
}
