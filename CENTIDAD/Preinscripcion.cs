using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class Preinscripcion {

        public string TieneImpuestoVerde { get; set; }   

	    private Operacion operacion;

		public Operacion Operacion {
			get { return operacion; }
			set { operacion = value; }
		}

		private double n_factura;

		public double N_factura {
			get { return n_factura; }
			set { n_factura = value; }
		}

		private string n_poliza;

		public string N_poliza {
			get { return n_poliza; }
			set { n_poliza = value; }
		}

		private string tag;

		public string Tag {
			get { return tag; }
			set { tag = value; }
		}
		
		private string legalizar;

		public string Legalizar {
			get { return legalizar; }
			set { legalizar = value; }
		}
		
		private string tipo_tramite;

		public string Tipo_tramite {
			get { return tipo_tramite; }
			set { tipo_tramite = value; }
		}
		
		private string cargo_venta;

		public string Cargo_venta {
			get { return cargo_venta; }
			set { cargo_venta = value; }
		}
		
		private DateTime fechafactura;

		public DateTime Fechafactura {
			get { return fechafactura; }
			set { fechafactura = value; }
		}
		
		private Persona adquiriente;

		public Persona Adquiriente {
			get { return adquiriente; }
			set { adquiriente = value; }
		}
		
		private BancoFinanciera bancofinanciera;

		public BancoFinanciera Bancofinanciera {
			get { return bancofinanciera; }
			set { bancofinanciera = value; }
		}
		
		private DistribuidorPoliza distribuidor_poliza;

		public DistribuidorPoliza Distribuidor_poliza {
			get { return distribuidor_poliza; }
			set { distribuidor_poliza = value; }
		}
		
		private Persona compra_para;

		public Persona Compra_para {
			get { return compra_para; }
			set { compra_para = value; }
		}
		
		private string tipo_pago_factura;

		public string Tipo_pago_factura {
			get { return tipo_pago_factura; }
			set { tipo_pago_factura = value; }
		}
		
		private double neto_factura;

		public double Neto_factura {
			get { return neto_factura; }
			set { neto_factura = value; }
		}
		
		private Int16 iva;

		public Int16 Iva {
			get { return iva; }
			set { iva = value; }
		}
		
		private string terminacion_especial;

		public string Terminacion_especial {
			get { return terminacion_especial; }
			set { terminacion_especial = value; }
		}
		
		private SucursalCliente sucursal_origen;

		public SucursalCliente Sucursal_origen {
			get { return sucursal_origen; }
			set { sucursal_origen = value; }
		}
		
		private SucursalCliente sucursal_destino;

		public SucursalCliente Sucursal_destino {
			get { return sucursal_destino; }
			set { sucursal_destino = value; }
		}

		private DatosVehiculo dato_vehiculo;

		public DatosVehiculo Dato_vehiculo {
			get { return dato_vehiculo; }
			set { dato_vehiculo = value; }
		}


		private double nota_venta;

		public double Nota_venta
		{
			get { return nota_venta; }
			set { nota_venta = value; }
		}

		private double rut_vendedor;

		public double Rut_vendedor
		{
			get { return rut_vendedor; }
			set { rut_vendedor = value; }
		}


        private string cit;

        public string Cit
        {
            get { return cit; }
            set { cit = value; }
        }

	}
}