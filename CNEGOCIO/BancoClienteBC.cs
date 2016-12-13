using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
	public class BancoClienteBC
	{
        public List<BancoCliente> getbancobycliente(string cliente)
		{
            List<BancoCliente> lgasto = new BancoClienteDAC().getbancobycliente(cliente);
			return lgasto;
		}

		public string add_banco_cliente(string codigo, int id_cliente)
		{


			string add = new BancoClienteDAC().add_banco_cliente(codigo, id_cliente);
			return add;


		}

		public string del_banco_cliente(string codigo, int id_cliente)
		{


			string add = new BancoClienteDAC().del_banco_cliente(codigo, id_cliente);
			return add;


		}


	}
}