using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class GastoOperacionPeru
	{
		private Operacion operacion;

		public Operacion Operacion
		{
			get { return operacion; }
			set { operacion = value; }
		}

		private TipoGastoPeru tipogasto;

		public TipoGastoPeru Tipogasto
		{
			get { return tipogasto; }
			set { tipogasto = value; }
		}

		private double monto;

		public double Monto
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

		private double cargo_cliente;

		public double Cargo_cliente
		{
			get { return cargo_cliente; }
			set { cargo_cliente = value; }
		}

		private double cargo_empresa;

		public double Cargo_empresa
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
	}
}