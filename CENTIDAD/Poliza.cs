using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Poliza
    {
        private Int32 id_solicitud;

        public Int32 Id_solicitud
        {
            get { return id_solicitud; }
            set { id_solicitud = value; }
        }

        private string npoliza;

        public string Npoliza
        {
            get { return npoliza; }
            set { npoliza = value; }
        }

        private Int64 nfolio;

        public Int64 Nfolio
        {
            get { return nfolio; }
            set { nfolio = value; }
        }

        private string distribuidor_poliza;

        public string Distribuidor_poliza
        {
            get { return distribuidor_poliza; }
            set { distribuidor_poliza = value; }
        }

        private DateTime vigencia_desde;

        public DateTime Vigencia_desde
        {
            get { return vigencia_desde; }
            set { vigencia_desde = value; }
        }

        private DateTime vigencia_hasta;

        public DateTime Vigencia_hasta
        {
            get { return vigencia_hasta; }
            set { vigencia_hasta = value; }
        }

        private Int32 prima;

        public Int32 Prima
        {
            get { return prima; }
            set { prima = value; }
        }

        private string url_poliza;

        public string Url_poliza
        {
            get { return url_poliza; }
            set { url_poliza = value; }
        }

        private Int32 ppiso;

        public Int32 Ppiso
        {
            get { return ppiso; }
            set { ppiso = value; }
        }

        private Int32 pagp;

        public Int32 Pagp
        {
            get { return pagp; }
            set { pagp = value; }
        }

        private Int32 pcliente;

        public Int32 Pcliente
        {
            get { return pcliente; }
            set { pcliente = value; }
        }

        private Int32 id_poliza;

        public Int32 Id_poliza
        {
            get { return id_poliza; }
            set { id_poliza = value; }
        }

		private bool poliza_vigente;

		public bool Poliza_vigente
		{
			get { return poliza_vigente; }
			set { poliza_vigente = value; }
		}
    }
}
