using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class TipoFormaPago
	{
		private int id_formapago;

		public int Id_FormaPago
		{
			get { return id_formapago; }
			set { id_formapago = value; }
		}

		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		private string codigo;

		public string Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}
	}
}
