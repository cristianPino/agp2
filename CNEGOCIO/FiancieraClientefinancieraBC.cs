using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class FinancieraClienteFinancieraBC
	{

		

		public List<BancoFinanciera> getallbancoallfinanciera()
		{
			return new BancofinancieraDAC().getallBancoallfinanciera();
		}

		public List<BancoFinanciera> getallbancoallfinancieracliente(int id_clientef)
		{
			return new BancofinancieraDAC().getallBancoallfinancieracliente(id_clientef);
		}

        public List<BancoFinanciera> getFinancieraCliente( Int32 id_cliente)
        {
            return new BancofinancieraDAC().getFinancieraCliente( id_cliente);
        }



		public string add_bancofinancieracliente(Int16 id_cliente, string id_clientefinanciera)
		{
			
			return new FinancieraClienteFinancieraDAC().add_bancofinancieracliente(id_cliente,id_clientefinanciera);
		}

		public string del_bancofinancieracliente(Int16 id_cliente, string id_clientefinanciera)
		{

			return new FinancieraClienteFinancieraDAC().del_bancofinancieracliente(id_cliente, id_clientefinanciera);
		}

		public BancoFinanciera getBancofinanciera(string codigo)
		{
			return new BancofinancieraDAC().getBancofinanciera(codigo);
		}

		public string add_bancofinanciera_automatica(string nombre)
		{
			return new BancofinancieraDAC().add_bancofinanciera_automatica(nombre);
		}
        public BancoFinanciera gettipodocbanco(string codigo)
        {
            return new BancofinancieraDAC().gettipodocbanco(codigo);
        }


	}
}