using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CENTIDAD {
	public class FormaPagoInmatriculacionBC {
		
		public string AddFormaPago(int id_solicitud, string numero_cuenta_corriente, int id_formapago, double monto_abono, DateTime fecha_abono, string codigo_banco, string cod_moneda, string observaciones) {
			FormaPagoInmatriculacion fp = new FormaPagoInmatriculacion();
			fp.Id_solicitud = id_solicitud;
			fp.Numero_cuenta_corriente = numero_cuenta_corriente;
			fp.Tipo_forma_pago = new TipoFormaPagoDAC().GetTipoFormaPago(id_formapago);
			fp.Monto_abono = monto_abono;
			fp.Fecha_abono = fecha_abono;
			fp.Banco = new BancofinancieraDAC().getBancofinanciera(codigo_banco);
			fp.Moneda = new TipoMonedaDAC().GetTipoMoneda(cod_moneda);
			fp.Observaciones = observaciones;
			return new FormaPagoInmatriculacionDAC().AddFormaPago(fp);
		}

		public string DelFormaPago(int id_solicitud)
		{
			return new FormaPagoInmatriculacionDAC().DelFormaPago(id_solicitud);
		}

		public List<FormaPagoInmatriculacion> GetFormaPago(int id_solicitud) {
			return new FormaPagoInmatriculacionDAC().GetFormaPago(id_solicitud);
		}
	}
}