using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class TipoCarroceriaBC
	{
		public TipoCarroceria GetTipoCarroceria(int cod_tipo_carroceria)
		{
			return new TipoCarroceriaDAC().GetTipoCarroceria(cod_tipo_carroceria);
		}

		public List<TipoCarroceria> GetTipoCarroceriaTodos()
		{
			return new TipoCarroceriaDAC().GetTipoCarroceriaTodos();
		}
	}
}
