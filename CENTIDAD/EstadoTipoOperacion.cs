using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class EstadoTipoOperacion
    {

		
        private int codigo_estado;

        public int Codigo_estado
        {
            get { return codigo_estado; }
            set { codigo_estado = value; }
        }
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string correo_cliente;

        public string Correo_cliente
        {
            get { return correo_cliente; }
            set { correo_cliente = value; }
        }
        private string correo_empresa;

        public string Correo_empresa
        {
            get { return correo_empresa; }
            set { correo_empresa = value; }
        }
        private Int16 orden;

        public Int16 Orden
        {
            get { return orden; }
            set { orden = value; }
        }

        private string cliente_estado;

        public string Cliente_estado
        {
            get { return cliente_estado; }
            set { cliente_estado = value; }
        }
        private string llamada;

        public string Llamada
        {
            get { return llamada; }
            set { llamada = value; }
        }


		private string lista_correo;

		public string Lista_correo
		{
			get { return lista_correo; }
			set { lista_correo = value; }
		}

		private string envia_adquirientes;

		public string Envia_adquirientes
		{
			get { return envia_adquirientes; }
			set { envia_adquirientes = value; }
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

		private int contado_estado;

		public int Contado_estado
		{
			get { return contado_estado; }
			set { contado_estado = value; }
		}


		private string id_documento;

		public string Id_documento
		{
			get { return id_documento; }
			set { id_documento = value; }
		}

        private Int32 id_grupo;

        public Int32 Id_grupo
        {
            get { return id_grupo; }
            set { id_grupo = value; }
        }

        private Boolean estado_manual;

        public Boolean Estado_manual
        {
            get { return estado_manual; }
            set { estado_manual = value; }
        }
    }
}
