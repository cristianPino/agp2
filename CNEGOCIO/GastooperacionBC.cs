using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
	public class GastooperacionBC
	{
		public List<GastoOperacion> Getgastooperacion(Int32 id_solicitud)
		{
			List<GastoOperacion> lgasto = new GastooperacionDAC().getGastooperacion(id_solicitud);
			return lgasto;
		}

		public List<GastoOperacion> Getgastooperaciontr(Int32 id_solicitud)
		{
			List<GastoOperacion> lgasto = new GastooperacionDAC().getGastooperacionTR(id_solicitud);
			return lgasto;
		}

		public List<GastoOperacion> Getgastooperacionmovimiento(Int32 id_solicitud, string tipo_movimiento)
		{
			List<GastoOperacion> lgasto = new GastooperacionDAC().getGastooperacionMovimiento(id_solicitud, tipo_movimiento);
			return lgasto;
		}

        public string add_gastooperacion(Int32 id_solicitud, Int16 id_tipogasto, Int32 monto, string cuenta_usuario, Int32 cargo_cliente, Int32 cargo_empresa, string chkgc, int sumarValor = 0)
        {
            string add = new GastooperacionDAC().add_Gastooperacion(id_solicitud, id_tipogasto, monto, cuenta_usuario, cargo_cliente, cargo_empresa, chkgc, sumarValor);
            return add;
        }



		public string add_gastooperacioncomunes(Int32 id_solicitud, string cuenta_usuario, string operacion, int id_cliente, int id_familia)
		{
			string add = new GastooperacionDAC().add_Gastooperacioncomunes(id_solicitud, cuenta_usuario, operacion, id_cliente, id_familia);
			return add;
		}

        public string del_gastooperacion(Int32 id_solicitud, Int16 id_tipogasto, string chkgc, string cuenta_usuario)
		{
			string add = new GastooperacionDAC().del_Gastooperacion(id_solicitud, id_tipogasto, chkgc,cuenta_usuario);
			return add;
		}

        public List<GastoOperacion> validacionGasto(Int32 id_solicitud)
        {
            List<GastoOperacion> lgasto = new GastooperacionDAC().validacionGasto(id_solicitud);
            return lgasto;
        }

        public List<GastoOperacion> Getgastooperacionmov(Int32 id_solicitud, string tipo_movimiento)
        {
            List<GastoOperacion> lgasto = new GastooperacionDAC().getGastooperacionMov(id_solicitud, tipo_movimiento);
            return lgasto;
        }
	}
}