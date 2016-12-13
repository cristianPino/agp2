using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class GastoOperacion
    {
        private Operacion operacion;

        public Operacion Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        private Tipogasto tipogasto;

        public Tipogasto Tipogasto
        {
            get { return tipogasto; }
            set { tipogasto = value; }
        }
        private Int32 monto;

        public Int32 Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        private DateTime fecha_movimiento;

        public DateTime Fecha_movimiento
        {
            get { return fecha_movimiento; }
            set { fecha_movimiento = value; }
        }
        private Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }

        private Int32 cargo_cliente;

        public Int32 Cargo_cliente
        {
            get { return cargo_cliente; }
            set { cargo_cliente = value; }
        }
        private Int32 cargo_empresa;

        public Int32 Cargo_empresa
        {
            get { return cargo_empresa; }
            set { cargo_empresa = value; }
        }

		private bool bloqueo;

		public bool Bloqueo
		{
			get { return bloqueo; }
			set { bloqueo = value; }
		}

        private string cuenta_facturacion;

        public string Cuenta_facturacion
        {
            get { return cuenta_facturacion; }
            set { cuenta_facturacion = value; }
        }
        private string opcional;

        public string Opcional
        {
            get { return opcional; }
            set { opcional = value; }
        }

    }
}
