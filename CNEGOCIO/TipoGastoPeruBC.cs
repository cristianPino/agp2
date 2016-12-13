using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class TipoGastoPeruBC
	{
		public TipoGastoPeru getTipoGastoPeru(Int16 id_tipogasto)
		{
			return new TipoGastoPeruDAC().getTipoGastoPeru(id_tipogasto);
		}
	}
}
