using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class TipoClasificacionVehicular
	{
		private int id_categoria;

		public int Id_categoria
		{
			get { return id_categoria; }
			set { id_categoria = value; }
		}

		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		private bool anexo;

		public bool Anexo
		{
			get { return anexo; }
			set { anexo = value; }
		}
	}
}