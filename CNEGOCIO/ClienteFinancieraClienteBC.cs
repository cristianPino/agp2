using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class ClienteFinanacieraClienteBC
	{

		public List<ClienteFinancieraCliente> getallbancofinanciera(string strcodigo,Int32 id_cliente)
		{
			return new ClienteBancoFinancieraDAC().getallBancofinanciera("0",0);
		}

		

	}
}