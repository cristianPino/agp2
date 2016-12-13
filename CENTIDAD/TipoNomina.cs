using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class TipoNomina
    {
        private int id_nomina;

        public int Id_nomina
        {
            get { return id_nomina; }
            set { id_nomina = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

		private int folio;

		public int Folio {
			get { return folio; }
			set { folio = value; }
		}

		private string reporte;

		public string Reporte
		{
			get { return reporte; }
			set { reporte = value; }
		}

		private int id_familia;

		public int Id_familia
		{
			get { return id_familia; }
			set { id_familia = value; }
		}

		private int orden_old;

		public int Orden_old
		{
			get { return orden_old; }
			set { orden_old = value; }
		}

		private int orden_new;

		public int Orden_new
		{
			get { return orden_new; }
			set { orden_new = value; }
		}


		private Int16 chek;

		public Int16 Chek
		{
			get { return chek; }
			set { chek = value; }
		}


		
		private Int32 codigo_estado;

		public Int32 Codigo_estado
		{
			get { return codigo_estado; }
			set { codigo_estado = value; }
		}

		
        private Int32 id_tipogasto;

        public Int32 Id_tipogasto
        {
            get { return id_tipogasto; }
            set { id_tipogasto = value; }
        }


        private bool permite_factura;

        public bool Permite_factura
        {
            get { return permite_factura; }
            set { permite_factura = value; }
        }

        private Int32 monto;

        public Int32 Monto
        {
            get { return monto; }
            set { monto = value; }
        }


        private Int32 id_inventario;

        public Int32 Id_inventario
        {
            get { return id_inventario; }
            set { id_inventario = value; }
        }

        private bool cliente_unico;

        public bool Cliente_unico
        {
            get { return cliente_unico; }
            set { cliente_unico = value; }
        }

    }
}