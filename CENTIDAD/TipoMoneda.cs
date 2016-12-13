using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class TipoMoneda
	{
		private string cod_moneda;

		public string Cod_moneda
		{
			get { return cod_moneda; }
			set { cod_moneda = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string simbolo;

		public string Simbolo
		{
			get { return simbolo; }
			set { simbolo = value; }
		}
	}
}
