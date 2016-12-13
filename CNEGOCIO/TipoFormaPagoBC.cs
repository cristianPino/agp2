using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class TipoFormaPagoBC
	{
		public TipoFormaPago GetTipoFormaPago(int id_formapago)
		{
			return new TipoFormaPagoDAC().GetTipoFormaPago(id_formapago);
		}

		public List<TipoFormaPago> GetTipoFormaPagoTodos()
		{
			return new TipoFormaPagoDAC().GetTipoFormaPagoTodos();
		}
	}
}
