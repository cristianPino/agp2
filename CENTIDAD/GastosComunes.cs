using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class GastosComunes
    {
        private Int32 valor;

        public Int32 Valor
        {
            get { return valor; }
            set { valor = value; }
        }

		

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private Boolean cargo_contable;

        public Boolean Cargo_contable
        {
            get { return cargo_contable; }
            set { cargo_contable = value; }
        }

        private Int32 id_tipogasto;

        public Int32 Id_tipogasto
        {
            get { return id_tipogasto; }
            set { id_tipogasto = value; }
        }

        private Boolean transferencia;

        public Boolean Transferencia
        {
            get { return transferencia; }
            set { transferencia = value; }
        }

		private bool factura;

		public bool Factura
		{
			get { return factura; }
			set { factura = value; }
		}

		private bool bloqueo;

		public bool Bloqueo
		{
			get { return bloqueo; }
			set { bloqueo = value; }
		}

		private string proveedor;

		public string Proveedor
		{
			get { return proveedor; }
			set { proveedor = value; }
		}

		private int id_familia;

		public int Id_familia
		{
			get { return id_familia; }
			set { id_familia = value; }
		}

        private PlandeCuenta plandecuenta;

        public PlandeCuenta Plandecuenta
        {
            get { return plandecuenta; }
            set { plandecuenta = value; }
        }
        private string cuenta_grupo;

        public string Cuenta_grupo
        {
            get { return cuenta_grupo; }
            set { cuenta_grupo = value; }
        }

        private string cuenta_facturacion;

        public string Cuenta_facturacion
        {
            get { return cuenta_facturacion; }
            set { cuenta_facturacion = value; }
        }

		private bool opcional;

		public bool Opcional
		{
			get { return opcional; }
			set { opcional = value; }
		}

        private bool comprobar;

        public bool Comprobar
        {
            get { return comprobar; }
            set { comprobar = value; }
        }

	}
}
