using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class AlertaestadoFamiliaBC
    {

		

		
        public List<AlertaestadoFamilia> getRegla_EstadoFamilia(Int16 id_familia, Int16 codigo_estado)
		{
            return new AlertaestadoFamiliaDAC().getRegla_EstadoFamilia(id_familia,  codigo_estado);
		}

        
        
		public string add_regla_estado_familia(Int16 codigo_estado, Int16 codigo_estado_regla)
		{
			string add = new AlertaestadoFamiliaDAC().add_regla_estado_familia(codigo_estado, codigo_estado_regla);
			return add;
		}

		
		public string del_regla_estado_familia(Int16 id_alerta, Int16 codigo_estado)
		{
			string add = new AlertaestadoFamiliaDAC().del_regla_estado_familia(id_alerta, codigo_estado);
			return add;
		}

    }
}
