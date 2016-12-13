using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Inmatriculacion
	{
		private Operacion operacion;

		public Operacion Operacion
		{
			get { return operacion; }
			set { operacion = value; }
		}

		private PersonaPeru comprador;

		public PersonaPeru Comprador
		{
			get { return comprador; }
			set { comprador = value; }
		}

		private PersonaPeru representante;

		public PersonaPeru Representante
		{
			get { return representante; }
			set { representante = value; }
		}

		private string numeroNotaPedido;

		public string NumeroNotaPedido
		{
			get { return numeroNotaPedido; }
			set { numeroNotaPedido = value; }
		}

		private string numeroDocumentoVenta;

		public string NumeroDocumentoVenta
		{
			get { return numeroDocumentoVenta; }
			set { numeroDocumentoVenta = value; }
		}

		private DateTime fechaEmisionDocumentoVenta;

		public DateTime FechaEmisionDocumentoVenta
		{
			get { return fechaEmisionDocumentoVenta; }
			set { fechaEmisionDocumentoVenta = value; }
		}

		private decimal montoTotalVehiculo;

		public decimal MontoTotalVehiculo
		{
			get { return montoTotalVehiculo; }
			set { montoTotalVehiculo = value; }
		}

		private string tipoMoneda;

		public string TipoMoneda
		{
			get { return tipoMoneda; }
			set { tipoMoneda = value; }
		}

		private string categoriaMtc;

		public string CategoriaMtc
		{
			get { return categoriaMtc; }
			set { categoriaMtc = value; }
		}

		private string usoMtc;

		public string UsoMtc
		{
			get { return usoMtc; }
			set { usoMtc = value; }
		}

		private string asesorComercial;

		public string AsesorComercial
		{
			get { return asesorComercial; }
			set { asesorComercial = value; }
		}

		private string administradorVenta;

		public string AdministradorVenta
		{
			get { return administradorVenta; }
			set { administradorVenta = value; }
		}

		private string formaPago;

		public string FormaPago
		{
			get { return formaPago; }
			set { formaPago = value; }
		}

		private SucursalCliente sucursal;

		public SucursalCliente Sucursal
		{
			get { return sucursal; }
			set { sucursal = value; }
		}

		private BancoFinanciera financiera;

		public BancoFinanciera Financiera
		{
			get { return financiera; }
			set { financiera = value; }
		}

		private string obs_fp;

		public string Obs_fp
		{
			get { return obs_fp; }
			set { obs_fp = value; }
		}

		private string cargo_venta;

		public string Cargo_venta
		{
			get { return cargo_venta; }
			set { cargo_venta = value; }
		}

		private double numero_titulo;

		public double Numero_titulo
		{
			get { return numero_titulo; }
			set { numero_titulo = value; }
		}

		private string obs_operacion;

		public string Obs_operacion
		{
			get { return obs_operacion; }
			set { obs_operacion = value; }
		}

		private string partida_electronica;

		public string Partida_electronica
		{
			get { return partida_electronica; }
			set { partida_electronica = value; }
		}

		private string ficha_nro;

		public string Ficha_nro
		{
			get { return ficha_nro; }
			set { ficha_nro = value; }
		}

		private string tomo;

		public string Tomo
		{
			get { return tomo; }
			set { tomo = value; }
		}

		private string fojas;

		public string Fojas
		{
			get { return fojas; }
			set { fojas = value; }
		}

		private string oficina_registral;

		public string Oficina_registral
		{
			get { return oficina_registral; }
			set { oficina_registral = value; }
		}
        private bool separacion_bienes;

        public bool Separacion_bienes
        {
            get { return separacion_bienes; }
            set { separacion_bienes = value; }
        }
        private bool dua;

        public bool Dua
        {
            get { return dua; }
            set { dua = value; }
        }
        private string part_elect_bienes;

        public string Part_elect_bienes
        {
            get { return part_elect_bienes; }
            set { part_elect_bienes = value; }
        }
        private string ofic_reg_bienes;

        public string Ofic_reg_bienes
        {
            get { return ofic_reg_bienes; }
            set { ofic_reg_bienes = value; }
        }


        private string vendedor;

        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }
	}
}