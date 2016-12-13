using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Operacion
    {
        public string tipo_operacion_ { get; set; }
        public string usuarioImpuestoVerde { get; set; }
        private Int32 id_solicitud;
        private Cliente cliente;
        private TipoOperacion tipo_operacion;
        private string estado;
        private Usuario usuario;
        private Int32 total_gasto;
        private Int32 total_ingreso;
        private Int32 total_devolucion;

        private Int32 factura_emitida;

        public Int32 Factura_emitida
        {
            get { return factura_emitida; }
            set { factura_emitida = value; }
        }

        public Int32 Total_devolucion
        {
            get { return total_devolucion; }
            set { total_devolucion = value; }
        }

        private Int32 numero_factura;

        private DateTime fecha_solicitud;

        public DateTime Fecha_solicitud
        {
            get { return fecha_solicitud; }
            set { fecha_solicitud = value; }
        }

        public Int32 Numero_factura
        {
            get { return numero_factura; }
            set { numero_factura = value; }
        }
        private string patente;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }
        private string numero_cliente;

        public string Numero_cliente
        {
            get { return numero_cliente; }
            set { numero_cliente = value; }
        }
        private Persona adquiriente;

        public Persona Adquiriente
        {
            get { return adquiriente; }
            set { adquiriente = value; }
        }

        public Int32 Total_ingreso
        {
            get { return total_ingreso; }
            set { total_ingreso = value; }
        }
        private Int32 total_egreso;

        public Int32 Total_egreso
        {
            get { return total_egreso; }
            set { total_egreso = value; }
        }

        public Int32 Total_gasto
        {
            get { return total_gasto; }
            set { total_gasto = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public  Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }
        

        public  Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        

        public  TipoOperacion Tipo_operacion
        {
            get { return tipo_operacion; }
            set { tipo_operacion = value; }
        }

		private double p_completado;

		public double P_completado
		{
			get { return p_completado; }
			set { p_completado = value; }
		}

		private SucursalCliente sucursal;

		public SucursalCliente Sucursal
		{
			get { return sucursal; }
			set { sucursal = value; }
		}

		private Estado_AGP estadoAGP;

		public Estado_AGP EstadoAGP
		{
			get { return estadoAGP; }
			set { estadoAGP = value; }
		}

		private int n_repertorio;

		public int N_repertorio
		{
			get { return n_repertorio; }
			set { n_repertorio = value; }
		}

        private string semaforo;

        public string Semaforo
        {
            get { return semaforo; }
            set { semaforo = value; }
        }
        private Int32 contador;

        public Int32 Contador
        {
            get { return contador; }
            set { contador = value; }
        }

        private Int32 total_dias;

        public Int32 Total_dias
        {
            get { return total_dias; }
            set { total_dias = value; }
        }


        private ParticipeOperacion participe;

        public ParticipeOperacion Participe
        {
            get { return participe; }
            set { participe = value; }
        }

        private Int32 id_estado;

        public Int32 Id_estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }

        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }


        private string cuenta_monto_factura;

        public string Cuenta_monto_factura
        {
            get { return cuenta_monto_factura; }
            set { cuenta_monto_factura = value; }
        }
        
        private string cuenta_gasto;

        public string Cuenta_gasto
        {
            get { return cuenta_gasto; }
            set { cuenta_gasto = value; }
        }
        private string familia;

        public string Familia
        {
            get { return familia; }
            set { familia = value; }
        }

        private Int32 folio;

        public Int32 Folio
        {
            get { return folio; }
            set { folio = value; }
        }

        private Int32 total_facturar;

        public Int32 Total_facturar
        {
            get { return total_facturar; }
            set { total_facturar = value; }
        }
        private string financiera;

        public string Financiera
        {
            get { return financiera; }
            set { financiera = value; }
        }

        private string num_cheque;

        public string Num_cheque
        {
            get { return num_cheque; }
            set { num_cheque = value; }
        }
        private Int32 id_inventario;

        public Int32 Id_inventario
        {
            get { return id_inventario; }
            set { id_inventario = value; }
        }

		private string facturanav;

		public string Facturanav
		{
			get { return facturanav; }
			set { facturanav = value; }
		}


		private int monto;

		public int Monto
		{
			get { return monto; }
			set { monto = value; }
		}

        private string nom_cliente;

        public string Nom_cliente
        {
            get { return nom_cliente; }
            set { nom_cliente = value; }
        }
        private string nom_sucursal;

        public string Nom_sucursal
        {
            get { return nom_sucursal; }
            set { nom_sucursal = value; }
        }

      
        private string producto;

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }


        private int id_cliente;

        public int Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        private string codigo_operacion;

        public string Codigo_operacion
        {
            get { return codigo_operacion; }
            set { codigo_operacion = value; }
        }


    }
}
