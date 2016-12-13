using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class MovimientoCuentaPeru
	{

		private Int32 id_movimiento_cuenta;

		public Int32 Id_movimiento_cuenta
		{
			get { return id_movimiento_cuenta; }
			set { id_movimiento_cuenta = value; }
		}
		
		private Operacion operacion;

		public Operacion Operacion
		{
			get { return operacion; }
			set { operacion = value; }
		}
		
		private CuentaBanco cuenta_banco;

		public CuentaBanco Cuenta_banco
		{
			get { return cuenta_banco; }
			set { cuenta_banco = value; }
		}
		
		private string numero_documento;

		public string Numero_documento
		{
			get { return numero_documento; }
			set { numero_documento = value; }
		}
		
		private DateTime fecha_movimiento;

		public DateTime Fecha_movimiento
		{
			get { return fecha_movimiento; }
			set { fecha_movimiento = value; }
		}
		
		private string tipo_movimiento;

		public string Tipo_movimiento
		{
			get { return tipo_movimiento; }
			set { tipo_movimiento = value; }
		}
		
		private string tipo_operacion;

		public string Tipo_operacion
		{
			get { return tipo_operacion; }
			set { tipo_operacion = value; }
		}
		
		private string documento_especial;

		public string Documento_especial
		{
			get { return documento_especial; }
			set { documento_especial = value; }
		}
		
		private TipoGastoPeru tipo_gasto;
		
		public TipoGastoPeru Tipo_gasto
		{
			get { return tipo_gasto; }
			set { tipo_gasto = value; }
		}

		private double monto;

		public double Monto
		{
			get { return monto; }
			set { monto = value; }
		}
		
		private Usuario usuario;

		public Usuario Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
	}
}