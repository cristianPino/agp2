using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class ComprobanteCobroFamilia
	{
		private int id_comprobante;

		public int Id_comprobante
		{
			get { return id_comprobante; }
			set { id_comprobante = value; }
		}

		private int id_familia;

		public int Id_familia
		{
			get { return id_familia; }
			set { id_familia = value; }
		}

		private string rpt_comprobante;

		public string Rpt_comprobante
		{
			get { return rpt_comprobante; }
			set { rpt_comprobante = value; }
		}
	}
}
