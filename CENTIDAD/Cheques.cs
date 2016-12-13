using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Cheques
    {

		private Int32 id_inventario;

		public Int32 Id_inventario
		{
			get { return id_inventario; }
			set { id_inventario = value; }
		}

		

		private BancoFinanciera bancofinanciera;

		public BancoFinanciera Bancofinanciera
		{
			get { return bancofinanciera; }
			set { bancofinanciera = value; }
		}

		private string rendido;

		public string Rendido
		{
			get { return rendido; }
			set { rendido = value; }
		}

		private string  num_cheq;

		public string Num_cheq
		{
			get { return num_cheq; }
			set { num_cheq = value; }
		}

		private string banco;

		public string Banco
		{
			get { return banco; }
			set { banco = value; }
		}

		

		private int ctacte;

		public int Ctacte
		{
			get { return ctacte; }
			set { ctacte = value; }
		}

		private int talonario;

		public int Talonario
		{
			get { return talonario; }
			set { talonario = value; }
		}

		private int monto_inicial;

		public int Monto_inicial
		{
			get { return monto_inicial; }
			set { monto_inicial = value; }
		}

		private int tipo_movimiento;

		public int Tipo_movimiento
		{
			get { return tipo_movimiento; }
			set { tipo_movimiento = value; }
		}

		private string numerocta;

		public string Numerocta
		{
			get { return numerocta; }
			set { numerocta = value; }
		}

		private string nombre_banco;

		public string Nombre_banco
		{
			get { return nombre_banco; }
			set { nombre_banco = value; }
		}

        private DateTime fecha_movimiento;

        public DateTime Fecha_movimiento
        {
            get { return fecha_movimiento; }
            set { fecha_movimiento = value; }
        }
        private Int32 monto_rendido;

        public Int32 Monto_rendido
        {
            get { return monto_rendido; }
            set { monto_rendido = value; }
        }
        private DateTime fecha_rendicion;

        public DateTime Fecha_rendicion
        {
            get { return fecha_rendicion; }
            set { fecha_rendicion = value; }
        }

        private string solicitante;

        public string Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
        }


		private string nomina;

		public string Nomina
		{
			get { return nomina; }
			set { nomina = value; }
		}

		private string folio;

		public string Folio
		{
			get { return folio; }
			set { folio = value; }
		}



    }
}
