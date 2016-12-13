using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class PlandeCuentaBC
    {

        public List<PlandeCuenta> getallplan(string strcodigo)
        {
            List<PlandeCuenta> lplan = new PlandeCuentaDAC().getallplan(strcodigo);
            return lplan;

        }

		public PlandeCuenta getplan(string strcodigo)
		{
			PlandeCuenta lplan = new PlandeCuentaDAC().getplan(strcodigo);
			return lplan;

		}

        public string add_plan (string codigo, string nombre)
        {

            PlandeCuenta mplan = new PlandeCuenta();

            mplan.Cuenta = codigo;
            mplan.Nombre = nombre;

            string plan = new PlandeCuentaDAC().add_plan(mplan);



            return plan;
        
        }


    }
}
