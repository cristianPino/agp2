using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
	public class Nomina_rendicionBC
    {


        public List<TipoNomina> getnomminarendicion(int id_inventario)
		{
            List<TipoNomina> get_lCta_Cte = new Nomina_rendicionDAC().getnomina_rendicion(id_inventario);
			return get_lCta_Cte;
		}


        public List<TipoNomina> Getnomina_rendida(Int32 id_inventario)
        {
            List<TipoNomina> add = new Nomina_rendicionDAC().Getnomina_rendida(id_inventario);
            return add;

        }


		public string  Delnomina_rendida(int id_nomina, int folio)
		{
			string add = new Nomina_rendicionDAC().Delnomina_rendida(id_nomina,folio);
			return add;

		}

		public string Addnomina_rendida(int id_nomina, int folio,int cheque)
		{
			string add = new Nomina_rendicionDAC().Addnomina_rendida(id_nomina, folio,cheque);
			return add;

		}

    }
}
