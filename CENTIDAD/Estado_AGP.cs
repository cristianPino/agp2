using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Estado_AGP
    {
        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
        private string pago;

        public string Pago
        {
            get { return pago; }
            set { pago = value; }
        }
        private DateTime fecha_pago;

        public DateTime Fecha_pago
        {
            get { return fecha_pago; }
            set { fecha_pago = value; }
        }
        private Int32 factura;

        public Int32 Factura
        {
            get { return factura; }
            set { factura = value; }
        }
        private DateTime fecha_factura;

        public DateTime Fecha_factura
        {
            get { return fecha_factura; }
            set { fecha_factura = value; }
        }
        private string proceso_agp;

        public string Proceso_agp
        {
            get { return proceso_agp; }
            set { proceso_agp = value; }
        }

		private bool repertorio_solicitado;

		public bool Repertorio_solicitado
		{
			get { return repertorio_solicitado; }
			set { repertorio_solicitado = value; }
		}
    }
}
