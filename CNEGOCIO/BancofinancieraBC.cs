using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class BancofinancieraBC
	{

		public List<BancoFinanciera> getallbancofinanciera(string strcodigo,Int32 id_cliente)
		{
			return new BancofinancieraDAC().getallBancofinanciera(strcodigo,id_cliente);
		}

		public List<BancoFinanciera> getFinancieraall(string usuario)
		{
			return new BancofinancieraDAC().getFinancieraall(usuario);
		}
        public List<BancoFinanciera> getFinancieraCliente( Int32 id_cliente)
        {
            return new BancofinancieraDAC().getFinancieraCliente( id_cliente);
        }



		public string add_bancofinanciera(string codigo, string nombre)
		{
			BancoFinanciera mbancofinanciera = new BancoFinanciera();
			mbancofinanciera.Codigo = codigo;
			mbancofinanciera.Nombre = nombre;
			return new BancofinancieraDAC().add_bancofinanciera(mbancofinanciera);
		}

		public int add_usuario_financiera(string cuenta_usuario, string financiera)
		{
			int add = new BancofinancieraDAC().add_usuario_financiera(cuenta_usuario,financiera);
			return add;
		}

		public int del_usuario_financiera(string cuenta_usuario, string financiera)
		{
			int add = new BancofinancieraDAC().del_usuario_financiera(cuenta_usuario, financiera);
			return add;
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

        public List<BancoFinanciera> getallbancoallfinanciera()
        {
            return new BancofinancieraDAC().getallBancoallfinanciera();
        }
		public List<BancoFinanciera> getallbancoallfinancieraconces()
		{
			return new BancofinancieraDAC().getallBancoallfinancieraconces();
		}


        public List<BancoFinanciera> getallbancoallfinancieracliente(int id_clientef)
        {
            return new BancofinancieraDAC().getallBancoallfinancieracliente(id_clientef);
        }

        public List<BancoFinanciera> getallbancoallfinancieracliente2(int id_clientef)
        {
            return new BancofinancieraDAC().getallBancoallfinancieracliente2(id_clientef);
        }

	}
}