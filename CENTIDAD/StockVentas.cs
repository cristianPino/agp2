using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class StockVentas
    {
        private Int32 id_dato_vehiculo;

        public Int32 Id_dato_vehiculo
        {
            get { return id_dato_vehiculo; }
            set { id_dato_vehiculo = value; }
        }

        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
        private string estado_venta;

        public string Estado_venta
        {
            get { return estado_venta; }
            set { estado_venta = value; }
        }
        private string fecha_venta;

        public string Fecha_venta
        {
            get { return fecha_venta; }
            set { fecha_venta = value; }
        }
        private Int32 iod_solicitud_venta;

        public Int32 Iod_solicitud_venta
        {
            get { return iod_solicitud_venta; }
            set { iod_solicitud_venta = value; }
        }


    }
}
