using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class PolizaBC
	{
		public string add_poliza(Poliza poliza,string usuario)
		{
			string mpoliza = new PolizaDAC().add_poliza(poliza,usuario);
			return mpoliza;
		}

		public string del_poliza(Int32 id_poliza)
		{
			string mpoliza = new PolizaDAC().del_poliza(id_poliza);
			return mpoliza;
		}

		public Poliza valores_poliza(Int32 id_solicitud, Int32 id_cliente, string codigo_distribuidor,string fecha_desde)
		{
			Poliza mpoliza = new PolizaDAC().getvalores_poliza(id_solicitud, id_cliente, codigo_distribuidor,fecha_desde);
			return mpoliza;
		}

		public List<Poliza> getallpoliza(Int32 id_solicitud)
		{
			List<Poliza> lpoliza = new PolizaDAC().getallpoliza(id_solicitud);
			return lpoliza;
		}

		public Poliza getpolizabyid_poliza(Int32 id_poliza)
		{
			Poliza pol = new PolizaDAC().getpolizabyid_poliza(id_poliza);
			return pol;
		}
	}
}