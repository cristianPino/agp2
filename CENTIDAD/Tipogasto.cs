using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Tipogasto
	{
		private short id_tipogasto;

		public short Id_tipogasto
		{
			get { return id_tipogasto; }
			set { id_tipogasto = value; }
		}
		private double valor;

		public double Valor
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

		private string cuenta;

		public string Cuenta
		{
			get { return cuenta; }
			set { cuenta = value; }
		}

		
		private Cliente cliente;

		public Cliente Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}
		private TipoOperacion tipooperacion;

		public TipoOperacion Tipooperacion
		{
			get { return tipooperacion; }
			set { tipooperacion = value; }
		}

		private Boolean cargo_contable;

		public Boolean Cargo_contable
		{
			get { return cargo_contable; }
			set { cargo_contable = value; }
		}

		private Boolean check;

		public Boolean Check
		{
			get { return check; }
			set { check = value; }
		}

		private Boolean habilitado;

		public Boolean Habilitado
		{
			get { return habilitado; }
			set { habilitado = value; }
		}

		


		private Boolean transferencia;

		public Boolean Transferencia
		{
			get { return transferencia; }
			set { transferencia = value; }
		}


        private Boolean factura;

        public Boolean Factura
        {
            get { return factura; }
            set { factura = value; }
        }



        private string cuenta_facturacion;

        public string Cuenta_facturacion
        {
            get { return cuenta_facturacion; }
            set { cuenta_facturacion = value; }
        }

	}
}