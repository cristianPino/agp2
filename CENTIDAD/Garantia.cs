using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Garantia
	{
		private Operacion operacion;

		public Operacion Operacion
		{
			get { return operacion; }
			set { operacion = value; }
		}

		private Cliente cliente;

		public Cliente Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}

		private SucursalCliente sucursal_origen;

		public SucursalCliente Sucursal_origen
		{
			get { return sucursal_origen; }
			set { sucursal_origen = value; }
		}
				
		private Persona adquiriente;
		
		public Persona Adquiriente
		{
			get { return adquiriente; }
			set { adquiriente = value; }
		}
		
		private Persona compra_para;
		
		public Persona Compra_para
		{
			get { return compra_para; }
			set { compra_para = value; }
		}
		
		private Persona compra_repre;
		
		public Persona Compra_repre
		{
			get { return compra_repre; }
			set { compra_repre = value; }
		}
		
		private double n_factura;
		
		public double N_factura
		{
			get { return n_factura; }
			set { n_factura = value; }
		}
		
		private string fechafactura;
		
		public string Fechafactura
		{
			get { return fechafactura; }
			set { fechafactura = value; }
		}
		
		private Persona emisor;
		
		public Persona Emisor
		{
			get { return emisor; }
			set { emisor = value; }
		}
		
		private double neto;
		
		public double Neto
		{
			get { return neto; }
			set { neto = value; }
		}
		
		private DatosVehiculo datos_vehiculo;
		
		public DatosVehiculo Datos_vehiculo
		{
			get { return datos_vehiculo; }
			set { datos_vehiculo = value; }
		}
		
		private double n_cheques;
		
		public double N_cheques
		{
			get { return n_cheques; }
			set { n_cheques = value; }
		}
		
		private string bancofinanciera;
		
		public string Bancofinanciera
		{
			get { return bancofinanciera; }
			set { bancofinanciera = value; }
		}
		
		private string cta_corriente;
		
		public string Cta_corriente
		{
			get { return cta_corriente; }
			set { cta_corriente = value; }
		}
		
		private string titular;
		
		public string Titular
		{
			get { return titular; }
			set { titular = value; }
		}
		
		private double n_cuotas;
		
		public double N_cuotas
		{
			get { return n_cuotas; }
			set { n_cuotas = value; }
		}

        private string fecha_primera;

        public string Fecha_primera
		{
			get { return fecha_primera; }
			set { fecha_primera = value; }
		}
		
		private string fecha_ultima;

        public string Fecha_ultima
		{
			get { return fecha_ultima; }
			set { fecha_ultima = value; }
		}
		
		private string notario;
		
		public string Notario
		{
			get { return notario; }
			set { notario = value; }

		}
		
		private string ciudad_notario;
		
		public string Ciudad_notario
		{
			get { return ciudad_notario; }
			set { ciudad_notario = value; }		
		}
		
		private double repertorio;
		
		public double Repertorio
		{
			get { return repertorio; }
			set { repertorio = value; }
		}
		
		private string fecha_contrato;
		
		public string Fecha_contrato
		{
			get { return fecha_contrato; }
			set { fecha_contrato = value; }
		}

		private double monto;
		
		public double Monto
		{
			get { return monto; }
			set { monto = value; }
		}

		private string creada;
		
		public string Creada
		{
			get { return creada; }
			set { creada = value; }

		}

		private string tipo_pago_factura;

		public string Tipo_pago_factura
		{
			get { return tipo_pago_factura; }
			set { tipo_pago_factura = value; }
		}

		private double factura_intereses;

		public double Factura_intereses
		{
			get { return factura_intereses; }
			set { factura_intereses = value; }
		}

		private string fecha_factura_intereses;

		public string Fecha_factura_intereses
		{
			get { return fecha_factura_intereses; }
			set { fecha_factura_intereses = value; }
		}

		private double monto_factura_intereses;

		public double Monto_factura_intereses
		{
			get { return monto_factura_intereses; }
			set { monto_factura_intereses = value; }
		}

        private string fecha_protocolizacion;

        public string Fecha_protocolizacion
        {
            get { return fecha_protocolizacion; }
            set { fecha_protocolizacion = value; }
        }
        private string n_protocolizacion;

        public string N_protocolizacion
        {
            get { return n_protocolizacion; }
            set { n_protocolizacion = value; }
        }

        private string n_RepertorioNotaria;

        public string N_RepertorioNotaria
        {
            get { return n_RepertorioNotaria; }
            set { n_RepertorioNotaria = value; }
        }

        private string n_RepertorioRNP;

        public string N_RepertorioRNP
        {
            get { return n_RepertorioRNP; }
            set { n_RepertorioRNP = value; }
        }

        private string fecha_repertorio;

        public string Fecha_repertorio
        {
            get { return fecha_repertorio; }
            set { fecha_repertorio = value; }
        }

        private string oficina_Registro;

        public string Oficina_Registro
        {
            get { return oficina_Registro; }
            set { oficina_Registro = value; }
        }

        private string ing_alza_PN_registro;

        public string Ing_alza_PN_registro
        {
            get { return ing_alza_PN_registro; }
            set { ing_alza_PN_registro = value; }
        }

        private string ing_alza_PH_registro;

        public string Ing_alza_PH_registro
        {
            get { return ing_alza_PH_registro; }
            set { ing_alza_PH_registro = value; }
        }

        private string n_solicitud_PN_registro;

        public string N_solicitud_PN_registro
        {
            get { return n_solicitud_PN_registro; }
            set { n_solicitud_PN_registro = value; }
        }

        private string n_solicitud_PH_registro;

        public string N_solicitud_PH_registro
        {
            get { return n_solicitud_PH_registro; }
            set { n_solicitud_PH_registro = value; }
        }

        private string nombreEstado;

        public string NombreEstado
        {
            get { return nombreEstado; }
            set { nombreEstado = value; }
        }

        private string fechaUltimoEstado;

        public string FechaUltimoEstado
        {
            get { return fechaUltimoEstado; }
            set { fechaUltimoEstado = value; }
        }

		private double valor_vehiculo;

		public double Valor_vehiculo
		{
			get { return valor_vehiculo; }
			set { valor_vehiculo = value; }
		}

		private double monto_pie;

		public double Monto_pie
		{
			get { return monto_pie; }
			set { monto_pie = value; }
		}

		private double factura_gastos;

		public double Factura_gastos
		{
			get { return factura_gastos; }
			set { factura_gastos = value; }
		}

		private string fecha_factura_gastos;

		public string Fecha_factura_gastos
		{
			get { return fecha_factura_gastos; }
			set { fecha_factura_gastos = value; }
		}

		private double monto_factura_gastos;

		public double Monto_factura_gastos
		{
			get { return monto_factura_gastos; }
			set { monto_factura_gastos = value; }
		}

		private double nro_credito;

		public double Nro_credito
		{
			get { return nro_credito; }
			set { nro_credito = value; }
		}

		private string doc_fundante;

		public string Doc_fundante
		{
			get { return doc_fundante; }
			set { doc_fundante = value; }
		}

		private string solicitante;

		public string Solicitante
		{
			get { return solicitante; }
			set { solicitante = value; }
		}

		private string notaria_protocolizacion;

		public string Notaria_protocolizacion
		{
			get { return notaria_protocolizacion; }
			set { notaria_protocolizacion = value; }
		}

		private string ciudad_notaria_protocolizacion;

		public string Ciudad_notaria_protocolizacion
		{
			get { return ciudad_notaria_protocolizacion; }
			set { ciudad_notaria_protocolizacion = value; }
		}

		private string fecha_repertorio_rnp;

		public string Fecha_repertorio_rnp
		{
			get { return fecha_repertorio_rnp; }
			set { fecha_repertorio_rnp = value; }
		}

		private string estado_solicitud_rnp;

		public string Estado_solicitud_rnp
		{
			get { return estado_solicitud_rnp; }
			set { estado_solicitud_rnp = value; }
		}

		private string estado_prenda;

		public string Estado_prenda
		{
			get { return estado_prenda; }
			set { estado_prenda = value; }
		}

        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

		private bool cav_comprado;

		public bool Cav_comprado
		{
			get { return cav_comprado; }
			set { cav_comprado = value; }
		}

		private string nro_declaracion;

		public string Nro_declaracion
		{
			get { return nro_declaracion; }
			set { nro_declaracion = value; }
		}

        private string fecha_pagare;

        public string Fecha_pagare
        {
            get { return fecha_pagare; }
            set { fecha_pagare = value; }
        }
        private int valor_Cuotas;

        public int Valor_Cuotas
        {
            get { return valor_Cuotas; }
            set { valor_Cuotas = value; }
        }
        private int capital_pagare;

        public int Capital_pagare
        {
            get { return capital_pagare; }
            set { capital_pagare = value; }
        }
        private int dia;

        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }
        private string tasa;

        public string Tasa
        {
            get { return tasa; }
            set { tasa = value; }
        }



	}
}