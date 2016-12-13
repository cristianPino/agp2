using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class ChequesFormaPago
	{
		private int id_cheque;

		public int Id_cheque
		{
			get { return id_cheque; }
			set { id_cheque = value; }
		}

		private int id_solicitud;

		public int Id_solicitud
		{
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}

		private int nro_cheque;

		public int Nro_cheque
		{
			get { return nro_cheque; }
			set { nro_cheque = value; }
		}

		private DateTime fecha_cheque;

		public DateTime Fecha_cheque
		{
			get { return fecha_cheque; }
			set { fecha_cheque = value; }
		}

		private int monto_cheque;

		public int Monto_cheque
		{
			get { return monto_cheque; }
			set { monto_cheque = value; }
		}

		private string codigo_banco;

		public string Codigo_banco
		{
			get { return codigo_banco; }
			set { codigo_banco = value; }
		}

		private string nro_cuenta;

		public string Nro_cuenta
		{
			get { return nro_cuenta; }
			set { nro_cuenta = value; }
		}
	}
}
