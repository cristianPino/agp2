using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class AlertaestadoCliente
    {

		private int id_alerta;

		public int Id_alerta
		{
			get { return id_alerta; }
			set { id_alerta = value; }
		}


		private EstadoTipoOperacion estado_alerta;

		public EstadoTipoOperacion Estado_alerta
		{
			get { return estado_alerta; }
			set { estado_alerta = value; }
		}

		private int id_cliente;

		public int Id_cliente
		{
			get { return id_cliente; }
			set { id_cliente = value; }
		}

		private string lista_correo;

		public string Lista_correo
		{
			get { return lista_correo; }
			set { lista_correo = value; }
		}


		private string envia_adquiriente;

		public string Envia_adquiriente
		{
			get { return envia_adquiriente; }
			set { envia_adquiriente = value; }
		}


		private int dias_primer_a;

		public int Dias_primer_a
		{
			get { return dias_primer_a; }
			set { dias_primer_a = value; }
		}


		private int dias_ultimo_a;

		public int Dias_ultimo_a
		{
			get { return dias_ultimo_a; }
			set { dias_ultimo_a = value; }
		}


		private int caducidad_estado;

		public int Caducidad_estado
		{
			get { return caducidad_estado; }
			set { caducidad_estado = value; }
		}


		private Int16 contador_estado;

		public Int16 Contador_estado
		{
			get { return contador_estado; }
			set { contador_estado = value; }
		}



		private int id_documento;

		public int Id_documento
		{
			get { return id_documento; }
			set { id_documento = value; }
		}


		private int codigo_estado;

		public int Codigo_estado
		{
			get { return codigo_estado; }
			set { codigo_estado = value; }
		}


		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		private string cheked;

		public string Cheked
		{
			get { return cheked; }
			set { cheked = value; }
		}


		private int id_familia;

		public int Id_familia
		{
			get { return id_familia; }
			set { id_familia = value; }
		}

        private string habilitado;

        public string Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }
    }
}
