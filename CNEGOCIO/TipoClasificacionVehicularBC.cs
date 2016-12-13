using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class TipoClasificacionVehicularBC
	{
		public TipoClasificacionVehicular GetTipoClasificacionVehicular(int id_categoria)
		{
			return new TipoClasificacionVehicularDAC().GetTipoClasificacionVehicular(id_categoria);
		}

		public List<TipoClasificacionVehicular> GetTipoClasificacionVehicularTodas()
		{
			return new TipoClasificacionVehicularDAC().GetTipoClasificacionVehicularTodas();
		}
	}
}
