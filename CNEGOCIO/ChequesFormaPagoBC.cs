using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
	public class ChequesFormaPagoBC
	{
		public string add_cheques_operacion(int id_cheque, int id_solicitud, int nro_cheque, DateTime fecha_cheque, int monto_cheque, string codigo_banco, string nro_cuenta)
		{
			ChequesFormaPago cheque = new ChequesFormaPago();
			cheque.Id_cheque = id_cheque;
			cheque.Id_solicitud = id_solicitud;
			cheque.Nro_cheque = nro_cheque;
			cheque.Fecha_cheque = fecha_cheque;
			cheque.Monto_cheque = monto_cheque;
			cheque.Codigo_banco = codigo_banco;
			cheque.Nro_cuenta = nro_cuenta;
			return new ChequesFormaPagoDAC().add_cheques_operacion(cheque);
		}

		public string del_cheques_operacion(int id_solicitud)
		{
			return new ChequesFormaPagoDAC().del_cheques_operacion(id_solicitud);
		}

		public List<ChequesFormaPago> get_cheques_operacion(int id_solicitud)
		{
			return new ChequesFormaPagoDAC().get_cheques_operacion(id_solicitud);
		}
	}
}