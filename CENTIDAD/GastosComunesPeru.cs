using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class GastosComunesPeru
	{
		private double valor;

		public double Valor
		{
			get { return valor; }
			set { valor = value; }
		}

		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		private Boolean cargo_contable;

		public Boolean Cargo_contable
		{
			get { return cargo_contable; }
			set { cargo_contable = value; }
		}

		private Int32 id_tipogasto;

		public Int32 Id_tipogasto
		{
			get { return id_tipogasto; }
			set { id_tipogasto = value; }
		}

		private Boolean transferencia;

		public Boolean Transferencia
		{
			get { return transferencia; }
			set { transferencia = value; }
		}

		private bool bloqueo;

		public bool Bloqueo
		{
			get { return bloqueo; }
			set { bloqueo = value; }
		}
	}
}
