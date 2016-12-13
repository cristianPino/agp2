using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
	public class ClienteOperacionTipogastoBC
    {
		

		public List<ClienteOperacionTipogasto> GetClienteOperaciontipogasto(int id_cliente, int id_familia, string codpro)
		{

			List<ClienteOperacionTipogasto> ltipogasto = new ClienteOperacionTipogastoDAC().GetClienteOperaciontipogasto(id_cliente, id_familia, codpro, 0);

			return ltipogasto;

		}


		public string add_cliente_operacion_tipogasto(int id_cliente, int id_familia, string codpro, int codigo)
		{


			string add = new ClienteOperacionTipogastoDAC().add_cliente_operacion_tipogasto(id_cliente, id_familia, codpro, codigo);
			return add;


		}

		public string del_cliente_operacion_tipogasto(int id_cliente, int id_familia, string codpro, int codigo)
		{


			string add = new ClienteOperacionTipogastoDAC().del_cliente_operacion_tipogasto(id_cliente, id_familia, codpro, codigo);
			return add;


		}

		public List<ClienteOperacionTipogasto> GetOperaciontipogasto( int id_familia, string codpro)
		{

			List<ClienteOperacionTipogasto> ltipogasto = new ClienteOperacionTipogastoDAC().GetOperaciontipogasto(id_familia, codpro);

			return ltipogasto;

		}

		public string add_operacion_tipogasto(int id_gasto, string codpro)
		{


			string add = new ClienteOperacionTipogastoDAC().add_operacion_tipogasto(id_gasto,codpro);
			return add;


		}


		public string del_operacion_tipogasto(string codpro, int id_gasto)
		{


			string add = new ClienteOperacionTipogastoDAC().del_operacion_tipogasto( codpro, id_gasto);
			return add;


		}

    }
}
