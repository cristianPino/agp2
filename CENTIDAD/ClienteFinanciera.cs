using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class ClienteFinanciera
	{
		private Int16 id_cliente;

		public Int16 Id_cliente
		{
			get { return id_cliente; }
			set { id_cliente = value; }
		}

		private string fechafel;

		public string Fechafel
		{
			get { return fechafel; }
			set { fechafel = value; }
		}

		private string nombrecliente;

		public string Nombrecliente
		{
			get { return nombrecliente; }
			set { nombrecliente = value; }
		}

		private string cuentausuario;

		public string Cuentausuario
		{
			get { return cuentausuario; }
			set { cuentausuario = value; }
		}

		private string rutcliente;

		public string Rutcliente
		{
			get { return rutcliente; }
			set { rutcliente = value; }
		}

		

		private DateTime fechahasta;

		public DateTime Fechahasta
		{
			get { return fechahasta; }
			set { fechahasta = value; }
		}

		private DateTime fechadesde;

		public DateTime Fechadesde
		{
			get { return fechadesde; }
			set { fechadesde = value; }
		}



		private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }
		private string financiera;

		public string Financiera
		{
			get { return financiera; }
			set { financiera = value; }
		}

        private string url_carpeta;

        public string Url_carpeta
        {
            get { return url_carpeta; }
            set { url_carpeta = value; }
        }
        private SucursalCliente sucursal;

        public SucursalCliente Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
	}
}