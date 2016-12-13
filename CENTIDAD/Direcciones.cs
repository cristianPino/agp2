using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Direcciones
	{
		private Int32 id_direccion;

		public Int32 Id_direccion
		{
			get { return id_direccion; }
			set { id_direccion = value; }
		}

		private string tipo_direccion;

		public string Tipo_direccion
		{
			get { return tipo_direccion; }
			set { tipo_direccion = value; }
		}

		private string direccion;

		public string Direccion
		{
			get { return direccion; }
			set { direccion = value; }
		}

		private Comuna comuna;

		public Comuna Comuna
		{
			get { return comuna; }
			set { comuna = value; }
		}

		//private int comuna;

		//public int Comuna
		//{
		//    get { return comuna; }
		//    set { comuna = value; }
		//}

		private string numero;

		public string Numero
		{
			get { return numero; }
			set { numero = value; }
		}

		private Int32 rut;

		public Int32 Rut
		{
			get { return rut; }
			set { rut = value; }
		}

		private string complemento;

		public string Complemento
		{
			get { return complemento; }
			set { complemento = value; }
		}

		private string check;

		public string Check
		{
			get { return check; }
			set { check = value; }
		}
	}
}