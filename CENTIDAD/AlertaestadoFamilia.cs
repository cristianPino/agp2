using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class AlertaestadoFamilia
	{

		private EstadoTipoOperacion estado_alerta;

		public EstadoTipoOperacion Estado_alerta
		{
			get { return estado_alerta; }
			set { estado_alerta = value; }
		}


		private string cheked;

		public string Cheked
		{
			get { return cheked; }
			set { cheked = value; }
		}



		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}


		private int codigo_estado;

		public int Codigo_estado
		{
			get { return codigo_estado; }
			set { codigo_estado = value; }
		}

		private int cod_est;


		public int Cod_est
		{
			get { return cod_est; }
			set { cod_est = value; }
		}

		private int id_familia;

		public int Id_familia
		{
			get { return id_familia; }
			set { id_familia = value; }
		}

		

	}
}
