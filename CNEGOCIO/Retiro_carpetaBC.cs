using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
	public class Retiro_carpetaBC
	{
		
		public string add_retiro_carpeta (string rut_adquiriente, int num_credito, string ejecutivo, int id_solicitud,string financiera,string concesionario,string prohibicion,string ot,string patente,string fecha_adjudicacion)
		{
            string add = new Retiro_carpetaDAC().add_retiro_carpeta(rut_adquiriente, num_credito, ejecutivo, id_solicitud, financiera, concesionario, prohibicion,ot,patente, fecha_adjudicacion);
			return add;
		}

        public Retiro_Carpeta getretiro(Int32 id_solicitud)
        {
            Retiro_Carpeta mretiro = new Retiro_carpetaDAC().getRetiroCarpeta(id_solicitud);
            return mretiro;

        }

        public Retiro_Carpeta getretirobycredito(Int32 credito)
        {
            Retiro_Carpeta mretiro = new Retiro_carpetaDAC().getRetiroCarpetabycredito(credito);
            return mretiro;

        }

		
	}
}