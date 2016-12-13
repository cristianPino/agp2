using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class ClienteOperacionTipogasto
	{
		private short id_tipogasto;

		public short Id_tipogasto
		{
			get { return id_tipogasto; }
			set { id_tipogasto = value; }
		}
	
		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		private string valor;

		public string Valor
		{
			get { return valor; }
			set { valor = value; }
		}

		

		private Boolean check;

		public Boolean Check
		{
			get { return check; }
			set { check = value; }
		}

		





	}
}