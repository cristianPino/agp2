using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class FormaPagoInmatriculacion {
		private int id_detalle_forma_pago;

		public int Id_detalle_forma_pago {
			get { return id_detalle_forma_pago; }
			set { id_detalle_forma_pago = value; }
		}

		private int id_solicitud;

		public int Id_solicitud {
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}

		private string numero_cuenta_corriente;

		public string Numero_cuenta_corriente {
			get { return numero_cuenta_corriente; }
			set { numero_cuenta_corriente = value; }
		}

		private TipoFormaPago tipo_forma_pago;

		public TipoFormaPago Tipo_forma_pago
		{
			get { return tipo_forma_pago; }
			set { tipo_forma_pago = value; }
		}

		private double monto_abono;

		public double Monto_abono {
			get { return monto_abono; }
			set { monto_abono = value; }
		}

		private DateTime fecha_abono;

		public DateTime Fecha_abono {
			get { return fecha_abono; }
			set { fecha_abono = value; }
		}

		private BancoFinanciera banco;

		public BancoFinanciera Banco
		{
			get { return banco; }
			set { banco = value; }
		}

		private TipoMoneda moneda;

		public TipoMoneda Moneda
		{
			get { return moneda; }
			set { moneda = value; }
		}

		private string observaciones;

		public string Observaciones
		{
			get { return observaciones; }
			set { observaciones = value; }
		}
	}
}