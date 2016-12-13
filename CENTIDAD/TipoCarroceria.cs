using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class TipoCarroceria
	{
		private int cod_tipo_carroceria;

		public int Cod_tipo_carroceria
		{
			get { return cod_tipo_carroceria; }
			set { cod_tipo_carroceria = value; }
		}

		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}
	}
}
