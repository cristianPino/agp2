using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class BancoCliente
	{

		private string id_cliente;

		public string Id_cliente
		{
			get { return id_cliente; }
			set { id_cliente = value; }
		}

		private string rut;

		public string Rut
		{
			get { return rut; }
			set { rut = value; }
		}

	 	private string codigo_banco;

		public string Codigo_banco
		{
			get { return codigo_banco; }
			set { codigo_banco = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string check;

		public string Check
		{
			get { return check; }
			set { check = value; }
		}
		

	}
}
