using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class StockVentasBC
    {
		public string add_sotckventas(Int32 id_solicitud, Int32 id_solicitud_venta, string estado_venta, Int32 id_dato_vehiculo, bool habilitada)
        {
			string add = new StockVentasDAC().add_stockventas(id_solicitud, id_solicitud_venta, estado_venta, id_dato_vehiculo, habilitada);
            return add;
        }

        public string del_stockventa_id_vehi(int id_Dato_vehiculo)
        {
            string add = new StockVentasDAC().del_stockventas(id_Dato_vehiculo);
            return add;
        }

        public string act_stockventa(int id_solicitud)
        {
            string add = new StockVentasDAC().act_stockventas(id_solicitud);
            return add;
        }

        public string act_stockventaImp(int id_solicitud,Int32 impuesto)
        {
            string add = new StockVentasDAC().act_stockventasImpuesto(id_solicitud,impuesto);
            return add;
        }
        public string act_compra(int id_solicitud)
        {
            string add = new StockVentasDAC().act_compra(id_solicitud);
            return add;
        }
    }
}
