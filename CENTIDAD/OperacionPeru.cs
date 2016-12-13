using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class OperacionPeru
	{
		private Int32 id_solicitud;
		private Cliente cliente;
		private TipoOperacion tipo_operacion;
		private string estado;
		private Usuario usuario;
		private double total_gasto;
		private double total_ingreso;
		private double total_devolucion;

		private Int32 factura_emitida;

		public Int32 Factura_emitida
		{
			get { return factura_emitida; }
			set { factura_emitida = value; }
		}

		public double Total_devolucion
		{
			get { return total_devolucion; }
			set { total_devolucion = value; }
		}

		private string numero_factura;

		private DateTime fecha_solicitud;

		public DateTime Fecha_solicitud
		{
			get { return fecha_solicitud; }
			set { fecha_solicitud = value; }
		}

		public string Numero_factura
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
		private PersonaPeru adquiriente;

		public PersonaPeru Adquiriente
		{
			get { return adquiriente; }
			set { adquiriente = value; }
		}

		public double Total_ingreso
		{
			get { return total_ingreso; }
			set { total_ingreso = value; }
		}
		private double total_egreso;

		public double Total_egreso
		{
			get { return total_egreso; }
			set { total_egreso = value; }
		}

		public double Total_gasto
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

		public Int32 Id_solicitud
		{
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}


		public Cliente Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}


		public TipoOperacion Tipo_operacion
		{
			get { return tipo_operacion; }
			set { tipo_operacion = value; }
		}
	}
}