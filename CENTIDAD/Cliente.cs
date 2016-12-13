using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Cliente
	{
		private Int16 id_cliente;

		public Int16 Id_cliente
		{
			get { return id_cliente; }
			set { id_cliente = value; }
		}
		private string imagen;

		public string Imagen
		{
			get { return imagen; }
			set { imagen = value; }
		}
		private Persona persona;

		public Persona Persona
		{
			get { return persona; }
			set { persona = value; }
		}

		private Boolean check;

		public Boolean Check
		{
			get { return check; }
			set { check = value; }
		}

		private Int16 id_webservice;

		public Int16 Id_webservice
		{
			get { return id_webservice; }
			set { id_webservice = value; }
		}

		private string fondo_pantalla;

		public string Fondo_Pantalla
		{
			get { return fondo_pantalla; }
			set { fondo_pantalla = value; }
		}

        private string codigo_nav;

        public string Codigo_nav
        {
            get { return codigo_nav; }
            set { codigo_nav = value; }
        }


		private string financiera;

		public string Financiera
		{
			get { return financiera; }
			set { financiera = value; }
		}

		private string facturanav;

		public string Facturanav
		{
			get { return facturanav; }
			set { facturanav = value; }
		}

		private string direccion;

		public string Direccion
		{
			get { return direccion; }
			set { direccion = value; }
		}

		private string numero;

		public string Numero
		{
			get { return numero; }
			set { numero = value; }
		}

		private string complemento;

		public string Complemento
		{
			get { return complemento; }
			set { complemento = value; }
		}
	}
}