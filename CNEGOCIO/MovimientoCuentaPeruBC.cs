using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class MovimientoCuentaPeruBC
	{
		public MovimientoCuentaPeru getMovimientocuentabyGasto(Int32 id_solicitud, string tipo_movimiento, Int16 id_tipogasto)
		{
			return new MovimientoCuentaPeruDAC().getMovimientocuentabyGasto(id_solicitud, tipo_movimiento, id_tipogasto);
		}

		public List<MovimientoCuentaPeru> getMovimientocuenta(Int32 id_solicitud, string tipo_movimiento)
		{
			return new MovimientoCuentaPeruDAC().getMovimientocuenta(id_solicitud, tipo_movimiento);
		}

		public string add_movimiento_cuenta(Int32 id_solicitud, Int16 id_cuenta_banco, Int16 id_tipo_gasto, string cuenta_usuario, string numero_documento, string tipo_movimiento, string tipo_operacion, string documento_especial, double monto, string chkgc)
		{
			return new MovimientoCuentaPeruDAC().add_Movimientocuenta(0, id_solicitud, id_cuenta_banco, id_tipo_gasto, numero_documento, tipo_movimiento, tipo_operacion, documento_especial, cuenta_usuario, monto, chkgc);
		}

		public string add_movimiento_cuentaPagoCompleto(Int32 id_solicitud, Int16 id_cuenta_banco, string cuenta_usuario, string numero_documento, string tipo_operacion, string documento_especial)
		{
			return new MovimientoCuentaPeruDAC().add_MovimientocuentaPagoCompleto(id_solicitud, id_cuenta_banco, numero_documento, tipo_operacion, documento_especial, cuenta_usuario);
		}

		public string del_movimiento_cuenta(Int32 id_movimiento_cuenta, string chkgc)
		{
			return new MovimientoCuentaPeruDAC().del_Movimientocuenta(id_movimiento_cuenta, chkgc);
		}
	}
}