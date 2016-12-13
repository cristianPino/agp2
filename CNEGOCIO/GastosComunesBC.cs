using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class GastosComunesBC
	{


        public List<Cotizacion> getallCotiza(string cuenta_usuario)
        {
            List<Cotizacion> lcotiza = new GastosComunesDAC().getallcotizacion(cuenta_usuario);
            return lcotiza;
        }
        public string add_cotizacion(string id_marca_vehiculo, string fecha_factura, int monto, string vendedor, string adquiriente)
		{
			string add = new GastosComunesDAC().add_cotizacion(id_marca_vehiculo,fecha_factura,monto,vendedor, adquiriente);
			return add;
		}

        public string add_GastosComunes(Int16 id_tipogasto, Int32 valor, string descripcion, string cargo_contable, string transferencia, string bloqueo, int id_familia, string plandecta, string proveedor, string factura, string opcional, string ctafac)
        {
            string add = new GastosComunesDAC().add_GastoasComunes(id_tipogasto, valor, descripcion, cargo_contable, transferencia, bloqueo, id_familia, plandecta, proveedor, factura, opcional, ctafac);
            return add;
        }




		public List<GastosComunes> getallGastosComunes(int id_familia)
		{
			List<GastosComunes> lGastosComunes = new GastosComunesDAC().getallGastosComunes(id_familia);
			return lGastosComunes;
		}

		public GastosComunes getGastosComunes(Int32 id_tipogasto)
		{
			GastosComunes mGastosComunes = new GastosComunesDAC().getGastosComunes(id_tipogasto);
			return mGastosComunes;
		}

        public GastosComunes getGastoComunbyId_solandId_gasto(Int32 id_solicitud, Int32 id_tipogasto)
        {
            GastosComunes mGastosComunes = new GastosComunesDAC().getGastoComunbyId_solandId_gasto(id_solicitud,id_tipogasto);
            return mGastosComunes;
        }

        public GastosComunes getGastos_Cero(Int32 id_solicitud)
        {
            GastosComunes mGastosComunes = new GastosComunesDAC().getGastos_Cero(id_solicitud);
            return mGastosComunes;
        }
	}
}