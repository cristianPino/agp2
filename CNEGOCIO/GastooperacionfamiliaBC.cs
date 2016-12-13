using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class GastoOperacionFamiliaBC
    {


		public List<Gastooperacionfamilia> getEstadoByTipooperacion(string id_familia,string cliente,string codpro)
        {
			List<Gastooperacionfamilia> lEstadotipooperacion = new GastooperacionfamiliaDAC().getEstadoByFamilia(id_familia,cliente,codpro);
            return lEstadotipooperacion;
        }

		

		public string add_operacion_cliente_gasto_comun(string codigo, string id_cliente, string id_tipogasto)
		{
			string add = new GastooperacionfamiliaDAC().add_operacion_cliente_gasto_comun(codigo, Convert.ToInt32(id_cliente), Convert.ToInt16(id_tipogasto));
			return add;
		}

		public string del_operacion_cliente_gasto_comun(string codigo, string id_cliente, string id_tipogasto)
		{
			string add = new GastooperacionfamiliaDAC().del_operacion_cliente_gasto_comun(codigo, Convert.ToInt32(id_cliente), Convert.ToInt16(id_tipogasto));
			return add;
		}



    }
}
