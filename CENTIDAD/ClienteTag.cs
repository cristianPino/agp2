using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class ClienteTag
	{
		private int id_cliente;

		public int Id_cliente
		{
			get { return id_cliente; }
			set { id_cliente = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}


		private string monto;

		public string Monto
		{
			get { return monto; }
			set { monto = value; }
		}

		private string montotag;

		public string Montotag
		{
			get { return montotag; }
			set { montotag = value; }
		}

		private int id_familia;

		public int Id_familia
		{
			get { return id_familia; }
			set { id_familia = value; }
		}

		private int id_codigo;

		public int Id_codigo
		{
			get { return id_codigo; }
			set { id_codigo = value; }
		}

		private string opcional;

		public string Opcional
		{
			get { return opcional; }
			set { opcional = value; }
		}

	}
    }

