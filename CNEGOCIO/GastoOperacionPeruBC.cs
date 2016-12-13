using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class GastoOperacionPeruBC
	{
		public List<GastoOperacionPeru> GetGastoOperacion(Int32 id_solicitud)
		{
			return new GastoOperacionPeruDAC().GetGastoOperacion(id_solicitud);
		}

		public List<GastoOperacionPeru> GetGastoOperacionMovimiento(Int32 id_solicitud, string tipo_movimiento)
		{
			return new GastoOperacionPeruDAC().GetGastoOperacionMovimiento(id_solicitud, tipo_movimiento);
		}

		public string AddGastoOperacion(Int32 id_solicitud, Int16 id_tipogasto, double monto, string cuenta_usuario, double cargo_cliente, double cargo_empresa, string chkgc)
		{
			return new GastoOperacionPeruDAC().AddGastoOperacion(id_solicitud, id_tipogasto, monto, cuenta_usuario, cargo_cliente, cargo_empresa, chkgc);
		}

		public string DelGastoOperacion(Int32 id_solicitud, Int16 id_tipogasto, string chkgc)
		{
			return new GastoOperacionPeruDAC().DelGastoOperacion(id_solicitud, id_tipogasto, chkgc);
		}
	}
}