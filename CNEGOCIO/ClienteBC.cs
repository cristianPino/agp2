using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class ClienteBC
	{

		public string add_cliente(Int32 rut_persona)
		{
			string add = new ClienteDAC().add_cliente(rut_persona);
			return add;
		}

		public string add_clientefinanciera(Int32 rut_persona, string financiera)
		{
			string add = new ClienteDAC().add_clientefinanciera(rut_persona, financiera);
			return add;
		}
        public List<Cliente> getclienteship()
        {
            List<Cliente> lcliente = new ClienteDAC().getclienteship();
            return lcliente;
        }


		public string add_usuario_cliente(Int16 id_cliente, string cuenta_usuario)
		{
			string add = new ClienteDAC().add_usuario_cliente(id_cliente, cuenta_usuario);
			return add;
		}

		public string del_usuario_cliente(Int16 id_cliente, string cuenta_usuario)
		{
			string add = new ClienteDAC().del_usuario_cliente(id_cliente, cuenta_usuario);
			return add;
		}

		public List<Cliente> getclientebyusuario(string cuenta_usuario)
		{
			List<Cliente> lcliente = new ClienteDAC().getclientesbyusuario(cuenta_usuario);
			return lcliente;
		}

		public List<Cliente> getUsuariocliente(string cuenta_usuario)
		{
			List<Cliente> lcliente = new ClienteDAC().getUsuarioclientes(cuenta_usuario);
			return lcliente;
		}

		public List<Cliente> getclientes()
		{
			List<Cliente> lcliente = new ClienteDAC().getclientes();
			return lcliente;
		}


		public List<ClienteFinanciera> getclientesfinan()
		{
			List<ClienteFinanciera> lcliente = new ClienteDAC().getclientesfinan();
			return lcliente;
		}

		public List<ClienteFinanciera> getclientesfinantxt(string cuenta_usuario, DateTime fechadesde, DateTime fechahasta)
		{
			List<ClienteFinanciera> lcliente = new ClienteDAC().getclientesfinantxt(cuenta_usuario,fechadesde,fechahasta);
			return lcliente;
		}
		public Cliente getcliente(Int16 id_cliente)
		{
			Cliente mcliente = new ClienteDAC().Getcliente(id_cliente);
			return mcliente;
		}

		public Cliente getClientePorRut(double rut)
		{
			return new ClienteDAC().getClientePorRut(rut);
		}

        public Cliente getclienteusuario(double rut_comprador,string cuenta_usuario)
        {
            return new ClienteDAC().getClienteusuario(rut_comprador,cuenta_usuario);
        }

        public List<Cliente> Get_clientesAgp_hipoteca()
        {
            return new ClienteDAC().Get_clientesAgp_hipoteca();
        }

        public Cliente getclientefac(Int16 id_cliente)
        {
            Cliente mcliente = new ClienteDAC().Getclientefac(id_cliente);
            return mcliente;
        }
	}
}